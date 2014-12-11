package controller;

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
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.TimeUnit;

// The Java class will be hosted at the URI path "/r"
@Path("/r")
public class MissionController {
    private static final int PORT = 53332;
    private static final URI BASE_URI = URI.create("http://localhost:" + PORT + "/");

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
    public String getIndex() {
        return null;
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
}
