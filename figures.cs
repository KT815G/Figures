public class Figure{
    public string Type;
    public int Layer;
    public int X, Y;
}

public class Rectangle: Figure{
    public int Width, Height;
    public Rectangle(int X, int Y, int Width, int Height){
        this.X=X;
        this.Y=Y;
        this.Width=Width;
        this.Height=Height;
    }
}


