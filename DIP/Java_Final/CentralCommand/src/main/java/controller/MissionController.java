package controller;

import MarsRoverKata.*;
import com.google.common.base.Function;
import com.google.common.base.Predicate;
import com.google.common.collect.Collections2;
import com.google.common.collect.ImmutableSet;
import com.google.common.collect.Lists;
import com.google.common.collect.Ordering;
import models.*;
import org.glassfish.grizzly.http.server.HttpServer;
import org.glassfish.grizzly.http.server.StaticHttpHandler;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import java.io.IOException;
import java.net.URI;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.TimeUnit;

// The Java class will be hosted at the URI path "/r"
@Path("/")
public class MissionController {
    private static final int PORT = 53332;
    private static final URI BASE_URI = URI.create("http://localhost:" + PORT + "/Mission");
    private static String defaultDocRoot;

    private static MissionManager missionManager;

    public static MissionManager getMissionManager() {
        if (null == missionManager) {
            try {
                missionManager = new MissionManager(new Rover(new Mars()));
            } catch (CrashException e) {
                e.printStackTrace();
            }
        }
        return missionManager;
    }

    public static void setMissionManager(MissionManager missionManager) { MissionController.missionManager = missionManager; }

    // The Java method will process HTTP GET requests
    @GET
    // The Java method will produce content identified by a specified MIME Media type
    @Produces(MediaType.APPLICATION_JSON)
    // Path determines the path, which is /r/example for this case
    @Path("/Example")
    public Response getExampleMessage() {
        Map<String, Integer> testMap = new HashMap<String, Integer>();
        testMap.put("One", 1);
        testMap.put("Twelve", 12);
        testMap.put("Three", 3);
        GenericEntity<Map<String, Integer>> e = new GenericEntity<Map<String, Integer>>(testMap) {
        };
        return Response.ok(testMap).build();
    }

    @GET
    @Path("/Index")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getIndex() {
        List<List<String>> initialMap = new ArrayList<>();
        for (int i = 0; i < getMissionManager().getPlanet().getBounds().getHeight(); i++) {
            if (i != getMissionManager().getRover().getLocation().getY()) {
                initialMap.add(getGroundRow());
            } else {
                initialMap.add(getRoverRow(getMissionManager().getRover()));
            }
        }

        MissionViewModel viewModel = new MissionViewModel();
        viewModel.setMap(initialMap);

        return Response.ok(viewModel).build();
    }

    @GET
    // The Java method will be hosted at the URI path "/r/reset"-
    @Path("/Reset")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getReset() {
        setMissionManager(null);
        return Response.temporaryRedirect(URI.create("/")).build();
    }

    @POST
    // The Java method will be hosted at the URI path "/r/reset"-
    @Path("/UpdateObstacles")
    @Produces(MediaType.APPLICATION_JSON)
    public Response updateObstacles(List<ObstacleViewModel> inputs) {
        if (inputs == null) {
            return Response.ok(new MissionResponseViewModel() {{
                setSuccess(false);
                setObstacles(new ArrayList<MapPositionViewModel>());
            }}).build();
        }

        Ordering<ObstacleViewModel> o = new Ordering<ObstacleViewModel>() {
            @Override
            public int compare(ObstacleViewModel left, ObstacleViewModel right) {
                return left.getCoordinates().compareTo(right.getCoordinates());
            }
        };

        List<ObstacleViewModel> distinctLocations = ImmutableSet.copyOf(o.sortedCopy(inputs)).asList();

        for (ObstacleViewModel input : distinctLocations) {
            String[] coordinates = input.getCoordinates().split("_");
            getMissionManager().addObstacle(Integer.parseInt(coordinates[0]), Integer.parseInt(coordinates[1]), input.getType(), input.getBehavior());
        }

        final List<MapPositionViewModel> updatedObstacles = convertToViewModels(getMissionManager().getPlanet().getObstacles());

        return Response.ok(new MissionResponseViewModel() {{
            setSuccess(true);
            setObstacles(updatedObstacles);
        }}).build();
    }

    @POST
    @Path("/SendCommands")
    @Produces(MediaType.APPLICATION_JSON)
    public Response sendCommands(CommandsViewModel input) {
        List<String> commands = input.getCommands();
        if (commands == null) {
            return Response.ok(new MissionResponseViewModel() {
                {
                    setSuccess(false);
                }
            }).build();
        }

        List<IObstacle> oldCollection = getMissionManager().getPlanet().getObstacles();

        final List<MapPositionViewModel> removedObstacles = Lists.newArrayList(Collections2.transform(Collections2.filter(oldCollection, new Predicate<IObstacle>() {
            @Override
            public boolean apply(final IObstacle input) {
                return input instanceof IMovable;
            }
        }), new Function<IObstacle, MapPositionViewModel>() {
            @Override
            public MapPositionViewModel apply(final IObstacle input) {
                return new MapPositionViewModel() {{
                    setLocation(input.getLocation().getX() + "_" + input.getLocation().getY());
                    setImage("Ground.png");
                }};
            }
        }));

        final String originalPosition = getMissionManager().getRover().getLocation().getX() + "_" + getMissionManager().getRover().getLocation().getY();
        String commandString = String.join(",", commands);

        getMissionManager().acceptCommands(commandString);
        getMissionManager().executeMission();

        final List<IObstacle> newCollection = getMissionManager().getPlanet().getObstacles();
        final List<MapPositionViewModel> updatedObstacles = convertToViewModels(getMissionManager().getPlanet().getObstacles());

        removedObstacles.addAll(
                Collections2.transform(Collections2.filter(oldCollection, new Predicate<IObstacle>() {
                            @Override
                            public boolean apply(final IObstacle input) {
                                return !newCollection.contains(input);
                            }
                        }), new Function<IObstacle, MapPositionViewModel>() {
                            @Override
                            public MapPositionViewModel apply(final IObstacle input) {
                                return new MapPositionViewModel() {{
                                    setLocation(input.getLocation().getX() + "_" + input.getLocation().getY());
                                    setImage("Ground.png");
                                }};
                            }
                        }
                ));

        final String roverNewPosition = getMissionManager().getRover().getLocation().getX() + "_" + getMissionManager().getRover().getLocation().getY();
        final String roverFacing = getFacingAsString(getMissionManager().getRover().getFacing());

        return Response.ok(new MissionResponseViewModel() {{
            setSuccess(true);
            setRoverLocation(roverNewPosition);
            setPreviousRoverLocation(originalPosition);
            setRoverFacing(roverFacing);
            setObstacles(updatedObstacles);
            setRemovedObstacles(removedObstacles);
        }}).build();
    }

    private List<MapPositionViewModel> convertToViewModels(List<IObstacle> obstacles) {
        return Lists.transform(obstacles, new Function<IObstacle, MapPositionViewModel>() {
            @Override
            public MapPositionViewModel apply(IObstacle input) {
                MapPositionViewModel mapPositionViewModel = new MapPositionViewModel();
                mapPositionViewModel.setLocation(input.getLocation().getX() + "_" + input.getLocation().getY());
                mapPositionViewModel.setImage(input.getClass().getSimpleName() + ".png");
                return mapPositionViewModel;
            }
        });
    }

    private String getFacingAsString(Direction roverFacing) {
        switch (roverFacing) {
            case North:
                return "N";
            case East:
                return "E";
            case South:
                return "S";
            case West:
                return "W";
        }
        return "N";
    }

    private List<String> getGroundRow() {
        List result = new ArrayList<String>();

        for (int i = 0; i < getMissionManager().getPlanet().getBounds().getWidth(); i++) {
            result.add("Ground.png");
        }
        return result;
    }

    private List<String> getRoverRow(Rover vehicle) {
        List<String> result = getGroundRow();

        int centerIndex = vehicle.getLocation().getX();
        result.set(centerIndex, "Rover.png");
        return result;
    }

    // MAIN - execution starting point
    public static void main(String[] args) throws IOException {
        final ResourceConfig resourceConfig = new ResourceConfig(MissionController.class);
        final HttpServer server = GrizzlyHttpServerFactory.createHttpServer(BASE_URI, resourceConfig);
        StaticHttpHandler httpHandler = new StaticHttpHandler("CentralCommand/src/main/webapp");
        defaultDocRoot = httpHandler.getDefaultDocRoot().getCanonicalPath();
        server.getServerConfiguration().addHttpHandler(httpHandler, "/");
        server.start();

        System.out.println("Server running");
        System.out.println("URL (example): http://localhost:" + PORT + "/index.html");
        System.out.println("Hit return to stop...");
        System.in.read();
        System.out.println("Stopping server");
        server.shutdown(0, TimeUnit.SECONDS);
        System.out.println("Server stopped");
    }
}
