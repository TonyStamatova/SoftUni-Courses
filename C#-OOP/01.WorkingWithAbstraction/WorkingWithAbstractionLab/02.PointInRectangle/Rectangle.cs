class Rectangle
{
    public Rectangle(Point topLeft, Point bottomRigth)
    {
        this.TopLeft = topLeft;
        this.BottomRight = bottomRigth;
    }

    private Point TopLeft { get; set; }

    private Point BottomRight { get; set; }

    public bool Contains(Point point)
    {
        if (IsInBorders(point.X, this.TopLeft.X, this.BottomRight.X) && IsInBorders(point.Y, this.TopLeft.Y, this.BottomRight.Y))
        {
            return true;
        }

        return false;
    }

    private bool IsInBorders(int pointLocation, int lowerBorder, int upperBorder)
    {
        if (pointLocation >= lowerBorder && pointLocation <= upperBorder)
        {
            return true;
        }

        return false;
    }
}

