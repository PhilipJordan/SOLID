package MarsRoverKata;

import com.google.common.base.Equivalence;

public class Point extends Equivalence<Point> {
    private int x;
    private int y;

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static Point add(Point p1, Point p2) {
        return new Point(p1.x + p2.x, p1.y + p2.y);
    }

    public static Point multiply(Point p1, int x) {
        return new Point(p1.x * x, p1.y * x);
    }


    public boolean equals(Object obj) {
        return obj != null && equals((Point) obj);
    }

    public boolean equals(Point other) {
        if (null == other) {
            return false;
        }
        if (this == other) {
            return true;
        }
        return x == other.x && y == other.y;
    }

    @Override
    public int doHash(Point point) {
        return (x * 397) ^ y;
    }

    @Override
    protected boolean doEquivalent(Point a, Point b) {
        return equals(a, b);
    }

    public static boolean equals(Point left, Point right) {
        return left.equals(right);
    }

    public static boolean notEquals(Point left, Point right) {
        return !equals(left, right);
    }

}

