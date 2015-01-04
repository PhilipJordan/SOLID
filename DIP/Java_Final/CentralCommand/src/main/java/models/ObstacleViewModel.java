package models;

public class ObstacleViewModel {

    public String Coordinates;

    public String Type;

    public String Behavior;

    public String getCoordinates() { return Coordinates; }

    public void setCoordinates(String coordinates) { Coordinates = coordinates; }

    public String getType() {
        return Type;
    }

    public void setType(String type) {
        Type = type;
    }

    public String getBehavior() {
        return Behavior;
    }

    public void setBehavior(String behavior) {
        Behavior = behavior;
    }
}