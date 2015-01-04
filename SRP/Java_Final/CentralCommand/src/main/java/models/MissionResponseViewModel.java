package models;

import java.util.List;

/**
 *
 */
public class MissionResponseViewModel {
    public boolean success;
    public String RoverLocation;

    public boolean isSuccess() {
        return success;
    }

    public void setSuccess(boolean success) {
        this.success = success;
    }

    public String getRoverLocation() {
        return RoverLocation;
    }

    public void setRoverLocation(String roverLocation) {
        RoverLocation = roverLocation;
    }

    public List<MapPositionViewModel> getObstacles() {
        return Obstacles;
    }

    public void setObstacles(List<MapPositionViewModel> obstacles) {
        Obstacles = obstacles;
    }

    public String getPreviousRoverLocation() {
        return PreviousRoverLocation;
    }

    public void setPreviousRoverLocation(String previousRoverLocation) {
        PreviousRoverLocation = previousRoverLocation;
    }

    public String getRoverFacing() {
        return RoverFacing;
    }

    public void setRoverFacing(String roverFacing) {
        RoverFacing = roverFacing;
    }

    public List<MapPositionViewModel> getRemovedObstacles() {
        return RemovedObstacles;
    }

    public void setRemovedObstacles(List<MapPositionViewModel> removedObstacles) {
        RemovedObstacles = removedObstacles;
    }

    public List<MapPositionViewModel> Obstacles;
    public String PreviousRoverLocation;
    public String RoverFacing;
    public List<MapPositionViewModel> RemovedObstacles;
}