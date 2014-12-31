package controller;

import MarsRoverKata.*;
import com.google.common.base.Function;
import com.google.common.collect.Lists;
import models.MapPositionViewModel;
import models.MissionViewModel;
import org.glassfish.grizzly.http.server.HttpServer;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;

import javax.ws.rs.GET;
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
@Path("/r")
public class MissionController {
    private static final int PORT = 53332;
    private static final URI BASE_URI = URI.create("http://localhost:" + PORT + "/");

    private MissionManager missionManager;

    public MissionManager getMissionManager() {
        if (null == missionManager) {
            try {
                this.missionManager = new MissionManager(new Rover(new Mars()));
            } catch (CrashException e) {
                e.printStackTrace();
            }
        }
        return missionManager;
    }

    public void setMissionManager(MissionManager missionManager) {
        this.missionManager = missionManager;
    }

    // The Java method will process HTTP GET requests
    @GET
    // The Java method will produce content identified by a specified MIME Media type
    @Produces(MediaType.APPLICATION_JSON)
    // Path determines the path, which is /r/example for this case
    @Path("/example")
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
    // The Java method will be hosted at the URI path "/r/reset"-
    @Path("/reset")
    @Produces(MediaType.APPLICATION_JSON)
    public String getReset() {
        // TODO: Reset
        return "Reset";
    }

    @GET
    @Path("/index")
    @Produces(MediaType.APPLICATION_JSON)
    public MissionViewModel getIndex() {
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

        //return View(viewModel);
        return viewModel;
    }

    // MAIN - execution starting point
    public static void main(String[] args) throws IOException {
        final ResourceConfig resourceConfig = new ResourceConfig(MissionController.class);
        final HttpServer server = GrizzlyHttpServerFactory.createHttpServer(BASE_URI, resourceConfig);

        server.start();

        System.out.println("Server running");
        System.out.println("URL (example): http://localhost:" + PORT + "/r/example");
        System.out.println("Hit return to stop...");
        System.in.read();
        System.out.println("Stopping server");
        server.shutdown(0, TimeUnit.SECONDS);
        System.out.println("Server stopped");
    }


    private List<MapPositionViewModel> convertToViewModels(List<IObstacle> obstacles) {
        return Lists.transform(obstacles, new Function<IObstacle, MapPositionViewModel>() {
            @Override
            public MapPositionViewModel apply(IObstacle input) {
                MapPositionViewModel mapPositionViewModel = new MapPositionViewModel();
                mapPositionViewModel.setLocation(input.getLocation().getX() + "_" + input.getLocation().getY());
                mapPositionViewModel.setImage(input.getClass().getName() + ".png");
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
}
