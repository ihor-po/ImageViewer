using ImageViewer.Helpers;

namespace ImageViewer.Models
{
    public class ImageFile : ObservableObject
    {
        #region Fields
        private string fileSource;
        private string fileName;
        private int fileSize;
        #endregion

        #region Properties
        public string FileSource
        {
            get { return fileSource; }
            set
            {
                fileSource = value;
                OnPropertyChanged("FileSource");
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public int FileSize
        {
            get { return fileSize; }
            set
            {
                fileSize = value;
                OnPropertyChanged("FileSize");
            }
        }
        #endregion
    }
}
