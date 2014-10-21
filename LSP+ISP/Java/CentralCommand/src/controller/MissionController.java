package controller;

import org.glassfish.grizzly.http.server.HttpServer;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import java.io.IOException;
import java.net.URI;
import java.util.concurrent.TimeUnit;

// The Java class will be hosted at the URI path "/r"
@Path("/r")
public class MissionController {
    private static final int PORT = 53332;
    private static final URI BASE_URI = URI.create("http://localhost:" + PORT + "/");

    // The Java method will process HTTP GET requests
    @GET
    // The Java method will produce content identified by the MIME Media type "text/plain"
    @Produces("text/plain")
    public String getClichedMessage() {
        // Return some cliched textual content
        return "Hello World";
    }

    @GET
    // The Java method will be hosted at the URI path "/r/reset"
    @Path("/reset")
    @Produces("text/plain")
    public String getReset() {
        // TODO: Reset
        return "Reset";
    }

    public static void main(String[] args) throws IOException {
        final ResourceConfig resourceConfig = new ResourceConfig(MissionController.class);
        final HttpServer server = GrizzlyHttpServerFactory.createHttpServer(BASE_URI, resourceConfig);

        server.start();

        System.out.println("Server running");
        System.out.println("Visit: http://localhost:" + PORT + "/r");
        System.out.println("Or: http://localhost:" + PORT + "/r/reset");
        System.out.println("Hit return to stop...");
        System.in.read();
        System.out.println("Stopping server");
        server.shutdown(0, TimeUnit.SECONDS);
        System.out.println("Server stopped");
    }
}
