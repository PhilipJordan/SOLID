/**
 * Created by philip on 5/16/2014.
 */
public class Program {
    public static void main(String[] arguments)
    {
        Everything all = new Everything();
        //Pokemon exception handling - Gotta collect 'em all
        try{
            all.Run();
        }catch(Exception ex){}
    }
}
