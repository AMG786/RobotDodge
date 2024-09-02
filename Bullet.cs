using SplashKitSDK;
public class Bullet
{
    private double _x, _y;
    private double _angle;
    private bool _active;
    private const int Speed = 8;
    private Circle _bulletCircle;
    private double _bulletRadius;
    public bool Active
    {
        get { return _active; }
    }
    public Bullet(double x, double y, double angle)
    {
        _x = x;
        _y = y;
        _angle = angle;
        _active = true;
        _bulletRadius = 5;
        _bulletCircle = SplashKit.CircleAt(_x, _y, 5);
    }

    public void Update()
    {
        if (_active)
        {
            Vector2D movement = new Vector2D();
            Matrix2D rotation = SplashKit.RotationMatrix(_angle);
            movement.X += Speed;
            movement = SplashKit.MatrixMultiply(rotation, movement);
            _x += movement.X;
            _y += movement.Y;

            _bulletCircle = SplashKit.CircleAt(_x, _y, 5);
            if (_x > SplashKit.ScreenWidth() || _x < 0 || _y > SplashKit.ScreenHeight() || _y < 0)
            {
                _active = false;
            }
        }
    }

    public void Draw()
    {
        if (_active)
        {
            _bulletCircle.Draw(Color.Red);
        }
    }

    public bool HasCollidedWith(Robot robot)
    {
        if (!_active)
            return false;

        double dx = _x - robot.X;
        double dy = _y - robot.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        return distance <= _bulletRadius + robot.Width / 2;
    }
}
