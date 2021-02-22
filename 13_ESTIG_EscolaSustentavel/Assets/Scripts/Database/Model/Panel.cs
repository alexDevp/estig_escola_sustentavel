namespace Database.Model
{
    public class Panel
    {
        private int _id;
        private string _name;
        private int _unitCount;
        private double _unitPrice;
        private int _points;
        private int _energyBefore;
        private int _dimensionWidth;
        private int _dimensionHeight;
        private int _power;
        private int _energyAfter;
        private string _finalInfoText;
        private string _imagePath;
        private string _arrangementImagePath;

        public Panel(int id, string name, int unitCount, double unitPrice, int points, int energyBefore, int dimensionWidth, int dimensionHeight, int power, int energyAfter, string finalInfoText, string imagePath, string arrangementImagePath)
        {
            _id = id;
            _name = name;
            _unitCount = unitCount;
            _unitPrice = unitPrice;
            _points = points;
            _energyBefore = energyBefore;
            _dimensionWidth = dimensionWidth;
            _dimensionHeight = dimensionHeight;
            _power = power;
            _energyAfter = energyAfter;
            _finalInfoText = finalInfoText;
            _imagePath = imagePath;
            _arrangementImagePath = arrangementImagePath;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int UnitCount
        {
            get => _unitCount;
            set => _unitCount = value;
        }

        public double UnitPrice
        {
            get => _unitPrice;
            set => _unitPrice = value;
        }

        public int Points
        {
            get => _points;
            set => _points = value;
        }

        public int EnergyBefore
        {
            get => _energyBefore;
            set => _energyBefore = value;
        }

        public int DimensionWidth
        {
            get => _dimensionWidth;
            set => _dimensionWidth = value;
        }

        public int DimensionHeight
        {
            get => _dimensionHeight;
            set => _dimensionHeight = value;
        }

        public int Power
        {
            get => _power;
            set => _power = value;
        }

        public int EnergyAfter
        {
            get => _energyAfter;
            set => _energyAfter = value;
        }

        public string FinalInfoText
        {
            get => _finalInfoText;
            set => _finalInfoText = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public string ArrangementImagePath
        {
            get => _arrangementImagePath;
            set => _arrangementImagePath = value;
        }
    }
}