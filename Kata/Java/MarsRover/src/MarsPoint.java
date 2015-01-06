
/**
 * Created by philip on 5/16/2014.
 */
public class MarsPoint extends Object
{
    private int x;
    private int y;

    public int getX(){ return this.x; }
    public int getY(){ return this.y; }

    public MarsPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static MarsPoint addPoints(MarsPoint p1, MarsPoint p2)
    {
        return new MarsPoint(p1.getX() + p2.getX(), p1.getY() + p2.getY());
    }

    public static MarsPoint multiplyPoints(MarsPoint p1, int x)
    {
        return new MarsPoint(p1.getX() * x, p1.getY() * x);
    }

    @Override public String toString()
    {
        return "MarsPoint x:" + this.x + " y:" + this.y;
    }

    @Override public boolean equals(Object obj)
    {
        if(!(obj instanceof MarsPoint))
        {
            return false;
        }

        MarsPoint other = (MarsPoint)obj;

        return this.getX() == other.getX() && this.getY() == other.getY();
    }
}