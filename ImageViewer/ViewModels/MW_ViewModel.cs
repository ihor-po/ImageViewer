using ImageViewer.Helpers;
using ImageViewer.Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace ImageViewer.ViewModels
{
    public class MW_ViewModel : ObservableObject
    {
        public ObservableCollection<ImageFile> Images { get; set; }
        private ImageFile selectedImage;
            
        public ImageFile SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                OnPropertyChanged("SelectedImage");
            }
        }

        public MW_ViewModel()
        {
            Images = new ObservableCollection<ImageFile>();
        }

        public RelayCommand addImageCommand;
        public RelayCommand deleteImageCommand;

        public RelayCommand AddImageCommand
        {
            get
            {
                return addImageCommand ?? new RelayCommand(
                    obj =>
                    {
                        OpenFileDialog fd = new OpenFileDialog();
                        fd.Filter = "image png (*.png)|*.png|image jpg (*.jpg)|*.jpg|All files (*.*)|*.*";
                        fd.FilterIndex = 1;
                        fd.Multiselect = true;
                        fd.RestoreDirectory = true;
                        if (fd.ShowDialog() == true)
                        {
                            if (fd.FileNames.Length > 1)
                            {
                                foreach (string newFile in fd.FileNames)
                                {
                                    AddNewImage(newFile);
                                }
                            }
                            else
                            {
                                AddNewImage(fd.FileName);
                            }
                            
                        }
                    }
                    );
            }
            set { addImageCommand = value; }
        }

        public RelayCommand DeleteImageCommand
        {
            get
            {
                return deleteImageCommand ?? new RelayCommand(
                    obj =>
                    {
                        ImageFile imageFile = obj as ImageFile;

                        if (imageFile != null)
                        {
                            Images.Remove(imageFile);
                        }
                    },
                    obj =>
                    {
                        return Images.Count > 0;
                    }
                    );
            }
            set { deleteImageCommand = value; }
        }

        /// <summary>
        /// Добавление нового файла
        /// </summary>
        /// <param name="newFile"></param>
        private void AddNewImage(string  newFile)
        {
            ImageFile imageFile = new ImageFile { FileSource = newFile};
            FileInfo fi = new FileInfo(newFile);
            imageFile.FileName = fi.Name;
            imageFile.FileSize = (int)fi.Length / 1024;
            Images.Add(imageFile);
        }

    }
}
