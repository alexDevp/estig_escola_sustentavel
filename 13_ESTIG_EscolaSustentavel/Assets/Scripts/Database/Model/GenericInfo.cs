namespace Database.Model
{
    public class GenericInfo
    {
        private int _id;
        private string _infoType;
        private string _content;

        public GenericInfo(int id, string infoType, string content)
        {
            _id = id;
            _infoType = infoType;
            _content = content;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string InfoType
        {
            get => _infoType;
            set => _infoType = value;
        }

        public string Content
        {
            get => _content;
            set => _content = value;
        }
    }
}