/**
 * Created by philip on 5/16/2014.
 */

import com.sun.xml.internal.fastinfoset.util.CharArray;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.io.*;

public class Everything
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    private Map<Direction, MarsPoint> PositionalAdjustments;
    private MarsSize MarsBounds;
    private ArrayList<MarsPoint> MarsObstacles;

    public Everything()
    {
        PositionalAdjustments = new HashMap<Direction, MarsPoint>();
        PositionalAdjustments.put(Direction.North, new MarsPoint(0, 1));
        PositionalAdjustments.put(Direction.South, new MarsPoint(0, -1));
        PositionalAdjustments.put(Direction.East, new MarsPoint(1, 0));
        PositionalAdjustments.put(Direction.West, new MarsPoint(-1, 0));

        MarsBounds = new MarsSize(100, 100);
        MarsObstacles = new ArrayList<MarsPoint>();
    }



    public void Run() throws CrashException
    {
        //MyHacking();
        Direction roverFacing = Direction.North;
        MarsPoint roverLocation = new MarsPoint(0, 0);

        CaptureObstacles();

        if(MarsObstacles.contains(roverLocation))
            throw new CrashException("Doh! We tried to land on something other than the planet and the rover was destroyed!!!");

        Write("Commands:");
        Write("f - Move Forward");
        Write("b - Move Backward");
        Write("r - Turn Right");
        Write("l - Turn Left");
        Write("q - End Mission (Single character command)");
        Write("h - Display Help (Single character command)");
        Write("You may issue multiple rover commands on one line.");
        Write("");
        Write("Mars Rover Mission Control!");

        String input = "";
        while(!input.equalsIgnoreCase("q")){
            if(input.equalsIgnoreCase("h")){
                Write("Commands:");
                Write("f - Move Forward");
                Write("b - Move Backward");
                Write("r - Turn Right");
                Write("l - Turn Left");
                Write("q - End Mission (Single character command)");
                Write("h - Display Help (Single character command)");
                Write("You may issue multiple rover commands on one line.");
                Write("");
            }
            else{
                boolean wasValid = true;
                char[] commands = input.toLowerCase().toCharArray();

                //String[] commands = input.split("(?!^)");
                for (int i = 0; i < commands.length; i++) {
                    if(wasValid){
                        char command = commands[i];
                        switch(command){
                            case 'f': {
                                MarsPoint adjustment = PositionalAdjustments.get(roverFacing);
                                MarsPoint desiredPosition = MarsPoint.addPoints(roverLocation, adjustment);
                                MarsPoint newLocation = CalculateFinalPosition(roverLocation, desiredPosition);

                                if(newLocation == roverLocation)
                                    wasValid = false;

                                roverLocation = newLocation;

                                break;
                            }
                            case 'b': {
                                MarsPoint adjustment = MarsPoint.multiplyPoints(PositionalAdjustments.get(roverFacing), -1);
                                MarsPoint desiredPosition = MarsPoint.addPoints(roverLocation, adjustment);
                                MarsPoint newLocation = CalculateFinalPosition(roverLocation, desiredPosition);

                                if(newLocation == roverLocation)
                                    wasValid = false;

                                roverLocation = newLocation;

                                break;
                            }
                            case 'r': {
                                if(roverFacing == Direction.North)
                                    roverFacing = Direction.East;
                                else if(roverFacing == Direction.South)
                                    roverFacing = Direction.West;
                                else if(roverFacing == Direction.East)
                                    roverFacing = Direction.South;
                                else if(roverFacing == Direction.West)
                                    roverFacing = Direction.North;

                                break;
                            }
                            case 'l': {
                                if(roverFacing == Direction.North)
                                    roverFacing = Direction.West;
                                else if(roverFacing == Direction.South)
                                    roverFacing = Direction.East;
                                else if(roverFacing == Direction.East)
                                    roverFacing = Direction.North;
                                else if(roverFacing == Direction.West)
                                    roverFacing = Direction.South;

                                break;
                            }
                        }
                    }
                }
                Write("The rover is now at X: " + roverLocation.getX() + " Y: " + roverLocation.getY());
                Write("The rover is facing " + roverFacing.toString());
                Write("");
                Write("");
                Write("Enter more commands to continue moving: ");
            }
            input = Read();
        }
    }

    private MarsPoint CalculateFinalPosition(MarsPoint roverLocation, MarsPoint desiredPosition)
    {
        MarsPoint newDestination = desiredPosition;
        if(desiredPosition.getY() > MarsBounds.getHeight())
        {
            newDestination = new MarsPoint(desiredPosition.getX(), 0);
        }
        if(desiredPosition.getY() < 0)
        {
            newDestination = new MarsPoint(desiredPosition.getX(), MarsBounds.getHeight());
        }
        if(desiredPosition.getX() > MarsBounds.getWidth())
        {
            newDestination = new MarsPoint(0, desiredPosition.getY());
        }
        if(desiredPosition.getX() < 0)
        {
            newDestination = new MarsPoint(MarsBounds.getWidth(), desiredPosition.getY());
        }

        boolean anyInstance = MarsObstacles.contains(newDestination);
        if(anyInstance)
        {
            return roverLocation;
        }

        return newDestination;
    }

    private void CaptureObstacles()
    {
        Write("Create Mars!");
        Write("Enter obstacles to the Mars landscape in X,Y format.");
        Write("Press [Enter] with no values when done");

        String input = Read();

        while(!IsNullOrWhiteSpace(input))//   input != null && !input.isEmpty())
        {
            String[] coordinates = input.split(",");
            MarsPoint location = new MarsPoint(TryParseInt(coordinates[0]), TryParseInt(coordinates[1]));
            MarsObstacles.add(location);
            input = Read();
        }
        Write("");

        //Verify - REMOVE THIS
        Write(MarsObstacles);
    }

    public void MyHacking()
    {
        Write("Say something I can echo:");
        String line = Read();
        //String line = "This is wrong";
        //BufferedReader buffer =new BufferedReader(new InputStreamReader(System.in));
        //try {
        //    line = buffer.readLine();
        //}catch(IOException ex)
        //{}
        Write(line);


        MarsPoint foo = new MarsPoint(1, 10);
        MarsPoint bar = new MarsPoint(2, 22);

        MarsPoint justSomething = MarsPoint.addPoints(foo, bar);
        Write(justSomething);


        Write(PositionalAdjustments);

        Foo();

    }

    public void Foo()
    {
        Write("Hello FooWorld!");
    }

    private boolean IsNullOrWhiteSpace(String aString)
    {
        return aString == null || aString.isEmpty();
    }

    //returns 0 if parse is unsuccessful
    private int TryParseInt(String number)
    {
        int result;
        try
        {
            result = Integer.parseInt(number);
        }
        catch (NumberFormatException nfe)
        {
            result = 0;
        }
        return result;
    }

    private String Read()
    {
        String line = "Sorry, I did not get that. Could you say it again?";
        BufferedReader buffer =new BufferedReader(new InputStreamReader(System.in));
        try {
            line = buffer.readLine();
        }catch(IOException ex)
        {}
        return line;
    }

    private void Write(Object somethingToPrint)
    {
        System.out.println(somethingToPrint);
    }
}
