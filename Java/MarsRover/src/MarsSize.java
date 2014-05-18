/**
 * Created by philip on 5/16/2014.
 */
public class MarsSize {

    private int _height;
    private int _width;

    public MarsSize(int height, int width){
        setHeight(height);
        setWidth(width);
    }

    public int getHeight(){
        return _height;
    }

    public void setHeight(int value){
        _height = value;
    }

    public int getWidth(){
        return _width;
    }

    public void setWidth(int value){
        _width = value;
    }

}
