using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace ShopSmart.Client
{
    public partial class PictureSliderProccessor 
    {
        public event EventHandler<ImageArgs> OnImageChanged;

        Image _currentImage;

        public Image CurrentImage
        {
            get { return _currentImage; }
        }

        ObservableCollection<Image> _images;
        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        public ObservableCollection<Image> Images
        {
            get { return _images; }
        }

        int _slideInterval;
        /// <summary>
        /// Gets or sets the slide interval.
        /// </summary>
        /// <value>
        /// The slide interval.
        /// </value>
        public int SlideInterval
        {
            get { return _slideInterval; }
            set
            {
                _slideInterval = value;
                this.SetInterval();
            }
        }

        Timer _tmrSloder;
        public PictureSliderProccessor(IList<Image> images,int slideInterval)
        {
            images = images ?? new List<Image>();
            InitializeComponent();
            this._images = new ObservableCollection<Image>();
            if (images.Count >0)
            {
                foreach (Image image in images)
                {
                    this._images.Add(image);
                }
            }
            this.Images.CollectionChanged += Images_CollectionChanged;
            

            this._tmrSloder = new Timer();
            this._slideInterval = slideInterval;
            this._tmrSloder.Tick += _tmrSloder_Tick;
            this.SetInterval();
            

        }

        //For designer
        public PictureSliderProccessor()
            : this(null, int.MaxValue)
        {
        }

        void Images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            bool hasImages = this._images.Count > 0;
            this._currentImage = hasImages ? this._images[0]: null ;
            this._tmrSloder.Enabled = hasImages;
        }

        void _tmrSloder_Tick(object sender, EventArgs e)
        {
            int imageTodiplayIdx = 0;
            Image displyedImage = this._currentImage;
            if (displyedImage != null && this._images.Count >1)
            {
                int currentIndex = this._images.IndexOf(displyedImage);
                 imageTodiplayIdx = (currentIndex+1) % (this._images.Count);
            }
            if (this._images.Count > imageTodiplayIdx)
            {
                Image ImageToDisplay = this._images[imageTodiplayIdx];
                this.SetImage(ImageToDisplay);
            }
            
            
        }

        private void SetImage(Image ImageToDisplay)
        {

            this._currentImage = ImageToDisplay;

            if (this.OnImageChanged != null)
            {
                this.OnImageChanged(this, new ImageArgs(this._currentImage));
            }

        }

        /// <summary>
        /// Sets the interval for slides.
        /// </summary>
        private void SetInterval()
        {
            this._tmrSloder.Stop();
            if (this._slideInterval != int.MaxValue)
            {
                this._tmrSloder.Interval = this._slideInterval;
                this._tmrSloder.Start();
            }
            
        }

       

    }

    public class ImageArgs:EventArgs
    {
        Image _image;

        public Image Image
        {
            get { return _image; }
        }

        public ImageArgs(Image img)
        {
            this._image = img;
        }
    }

}
