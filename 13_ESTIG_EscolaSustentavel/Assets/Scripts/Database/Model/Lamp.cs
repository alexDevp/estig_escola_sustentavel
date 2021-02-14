namespace Database.Model
{
    public class Lamp
    {
        private int _id;
        private string _name;
        private int _unitCount;
        private double _unitPrice;
        private int _points;
        private int _energyBefore;
        private int _power;
        private int _energyAfter;
        private string _infoText;
        private string _positiveText;
        private string _negativeText;
        private string _image_path;
        private string _arrangement_image_path;

        public string ImagePath
        {
            get => _image_path;
            set => _image_path = value;
        }

        public string ArrangementImagePath
        {
            get => _arrangement_image_path;
            set => _arrangement_image_path = value;
        }

        public Lamp(int id, string name, int unitCount, double unitPrice, int points, int energyBefore, int power, int energyAfter, string infoText, string positiveText, string negativeText, string imagePath, string arrangementImagePath)
        {
            _id = id;
            _name = name;
            _unitCount = unitCount;
            _unitPrice = unitPrice;
            _points = points;
            _energyBefore = energyBefore;
            _power = power;
            _energyAfter = energyAfter;
            _infoText = infoText;
            _positiveText = positiveText;
            _negativeText = negativeText;
            _image_path = imagePath;
            _arrangement_image_path = arrangementImagePath;
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

        public string InfoText
        {
            get => _infoText;
            set => _infoText = value;
        }

        public string PositiveText
        {
            get => _positiveText;
            set => _positiveText = value;
        }

        public string NegativeText
        {
            get => _negativeText;
            set => _negativeText = value;
        }
    }
}