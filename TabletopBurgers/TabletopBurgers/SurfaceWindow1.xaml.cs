using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Drag_and_Drop
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        #region Collections
        private ObservableCollection<PhotoData> libraryItemsTop;
        private ObservableCollection<PhotoData> libraryItemsBottom;
        private ObservableCollection<PhotoData> libraryItemsLeft;
        private ObservableCollection<PhotoData> libraryItemsRight;


        private ObservableCollection<PhotoData> burgerItems;
        private ObservableCollection<PhotoData> scatterItemsTop;
        private ObservableCollection<PhotoData> scatterItemsBottom;
        private ObservableCollection<PhotoData> scatterItemsRight;
        private ObservableCollection<PhotoData> scatterItemsLeft;

        private Dictionary<long, Tag> tagItems;
        private Dictionary<String, long> tabTags;

        public ObservableCollection<PhotoData> LibraryItemsTop
        {
            get
            {
                if (libraryItemsTop == null)
                {
                    libraryItemsTop = new ObservableCollection<PhotoData>();
                }

                return libraryItemsTop;
            }
        }
        public ObservableCollection<PhotoData> LibraryItemsBottom
        {
            get
            {
                if (libraryItemsBottom == null)
                {
                    libraryItemsBottom = new ObservableCollection<PhotoData>();
                }

                return libraryItemsBottom;
            }
        }

        public ObservableCollection<PhotoData> LibraryItemsLeft
        {
            get
            {
                if (libraryItemsLeft == null)
                {
                    libraryItemsLeft = new ObservableCollection<PhotoData>();
                }

                return libraryItemsLeft;
            }
        }

        public ObservableCollection<PhotoData> LibraryItemsRight
        {
            get
            {
                if (libraryItemsRight == null)
                {
                    libraryItemsRight = new ObservableCollection<PhotoData>();
                }

                return libraryItemsRight;
            }
        }

        public ObservableCollection<PhotoData> ScatterItemsTop
        {
            get
            {
                if (scatterItemsTop == null)
                {
                    scatterItemsTop = new ObservableCollection<PhotoData>();
                }

                return scatterItemsTop;
            }
        }

        public ObservableCollection<PhotoData> ScatterItemsBottom
        {
            get
            {
                if (scatterItemsBottom == null)
                {
                    scatterItemsBottom = new ObservableCollection<PhotoData>();
                }

                return scatterItemsBottom;
            }
        }

        public ObservableCollection<PhotoData> ScatterItemsRight
        {
            get
            {
                if (scatterItemsRight == null)
                {
                    scatterItemsRight = new ObservableCollection<PhotoData>();
                }

                return scatterItemsRight;
            }
        }

        public ObservableCollection<PhotoData> ScatterItemsLeft
        {
            get
            {
                if (scatterItemsLeft == null)
                {
                    scatterItemsLeft = new ObservableCollection<PhotoData>();
                }

                return scatterItemsLeft;
            }
        }

      
        public ObservableCollection<PhotoData> BurgerItems
        {
            get
            {
                if (burgerItems == null)
                {
                    burgerItems = new ObservableCollection<PhotoData>();
                }

                return burgerItems;
            }
        }

        public Dictionary<long, Tag> TagItems
        {
            get
            {
                if (tagItems == null)
                {
                    tagItems = new Dictionary<long, Tag>();
                }

                return tagItems;
            }
        }

        public Dictionary<String, long> TabTags
        {
            get
            {
                if (tabTags == null)
                {
                    tabTags = new Dictionary<String, long>();
                }

                return tabTags;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            this.DataContext = this;

            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            Place_tag_right.TouchEnter += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchEnter_right);
            Place_tag_left.TouchEnter += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchEnter_left);
            Place_tag_up.TouchEnter += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchEnter_up);
            Place_tag_down.TouchEnter += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchEnter_down);

            //Need to test this in the actual tabletop
            //Comment for other computer-testing meanwhile
            Place_tag_right.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_right);
            Place_tag_left.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_left);
            Place_tag_up.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_up);
            Place_tag_down.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_down);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;

            LibraryItemsTop.Add(new PhotoData("Images/BottomBreadTS.png", "Bottom Bread", 10));
            LibraryItemsTop.Add(new PhotoData("Images/TopBreadTS.png", "Top Bread", 10));
            LibraryItemsTop.Add(new PhotoData("Images/BrawnBreadTS.png", "Bottom Bread", 10));
            LibraryItemsTop.Add(new PhotoData("Images/BrawonBreadTS.png", "Top Bread", 10));


            LibraryItemsBottom.Add(new PhotoData("Images/CucumberTS.png", "Cucumber", 5));
            LibraryItemsBottom.Add(new PhotoData("Images/TomatoSliceTS.png", "Tomato", 3));
            LibraryItemsBottom.Add(new PhotoData("Images/LuttesTS.png", "Lettuce", 2));
            LibraryItemsBottom.Add(new PhotoData("Images/OnionTS.png", "Onions", 3));


            LibraryItemsLeft.Add(new PhotoData("Images/DobleCheeseTS.png", "Double Cheese", 7));
            LibraryItemsLeft.Add(new PhotoData("Images/CHesseTS.png", "Cheese", 7));
            LibraryItemsLeft.Add(new PhotoData("Images/Ketchup.png", "Ketchup", 1));


            LibraryItemsRight.Add(new PhotoData("Images/MeetTS.png", "Meat 2", 30));
            LibraryItemsRight.Add(new PhotoData("Images/DoubleMeetTS.png", "Meat", 25));
            LibraryItemsRight.Add(new PhotoData("Images/EggTS.png", "Egg    ", 10));
            LibraryItemsRight.Add(new PhotoData("Images/BaconTS.png", "Bacon    ", 10));

            TagItems.Add(1, new Tag(1, 387, "Stockholm", new DateTime(2015, 5, 20, 12, 51, 28), 8, false, -1));
            TagItems.Add(2, new Tag(2, 7843, "Copenhagen", new DateTime(2015, 5, 20, 14, 28, 03), -1, false, -1));
            TagItems.Add(3, new Tag(3, 987, "Uppsala", new DateTime(2015, 5, 20, 12, 35, 0), 3, false, -1));
            TagItems.Add(4, new Tag(4, 341, "Oslo", new DateTime(2015, 5, 20, 11, 20, 0), 15, true, 3));
            TagItems.Add(5, new Tag(5, 501, "Malmö", new DateTime(2015, 5, 20, 11, 22, 0), -1, false, -1));
            TagItems.Add(6, new Tag(6, 2453, "Jönköping", new DateTime(2015, 5, 20, 12, 03, 0), 12, true, 10));

            BurgerItems.Add(new PhotoData("Images/Burger1TS.png", "King burger", 70));
            BurgerItems.Add(new PhotoData("Images/Burger2TS.png", "Popular choice", 70));
            BurgerItems.Add(new PhotoData("Images/Burger3.png", "Ready from the kitchen", 70));
            BurgerItems.Add(new PhotoData("Images/Burger4.png", "Grilled texan", 70));
            BurgerItems.Add(new PhotoData("Images/FinalBurgerTS.png", "Deluxe cheddar", 70));
            BurgerItems.Add(new PhotoData("Images/Burger1TS.png", "King burger", 70));
            BurgerItems.Add(new PhotoData("Images/Burger2TS.png", "Popular choice", 70));
            BurgerItems.Add(new PhotoData("Images/Burger3.png", "Ready from the kitchen", 70));
            BurgerItems.Add(new PhotoData("Images/Burger4.png", "Grilled texan", 70));
            BurgerItems.Add(new PhotoData("Images/FinalBurgerTS.png", "Deluxe cheddar", 70));
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void Scatter_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement findSource = e.OriginalSource as FrameworkElement;
            ScatterViewItem draggedElement = null;

            // Find the ScatterViewitem object that is being touched.
            while (draggedElement == null && findSource != null)
            {
                if ((draggedElement = findSource as ScatterViewItem) == null)
                {
                    findSource = VisualTreeHelper.GetParent(findSource) as FrameworkElement;
                }
            }

            if (draggedElement == null)
            {
                return;
            }

            PhotoData data = draggedElement.Content as PhotoData;

            // Create the cursor visual
            ContentControl cursorVisual = new ContentControl()
            {
                Content = draggedElement.DataContext,
                Style = FindResource("HamburgerCursorStyle") as Style
            };

            // Create a list of input devices. Add the touches that
            // are currently captured within the dragged element and
            // the current touch (if it isn't already in the list).
            List<InputDevice> devices = new List<InputDevice>();
            devices.Add(e.TouchDevice);
            foreach (TouchDevice touch in draggedElement.TouchesCapturedWithin)
            {
                if (touch != e.TouchDevice)
                {
                    devices.Add(touch);
                }
            }

            // Get the drag source object
            ItemsControl dragSource = ItemsControl.ItemsControlFromItemContainer(draggedElement);

            SurfaceDragDrop.BeginDragDrop(
                dragSource,                     // The ScatterView object that the cursor is dragged out from.
                draggedElement,                 // The ScatterViewItem object that is dragged from the drag source.
                cursorVisual,                   // The visual element of the cursor.
                draggedElement.DataContext,     // The data attached with the cursor.
                devices,                        // The input devices that start dragging the cursor.
                DragDropEffects.Move);          // The allowed drag-and-drop effects of this operation.

            // Prevents the default touch behavior from happening and disrupting our code.
            e.Handled = true;

            // Hide the ScatterViewItem for now. We will remove it if the DragDrop is successful.
            draggedElement.Visibility = Visibility.Hidden;
        }

        private void Scatter_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData data = e.Cursor.Data as PhotoData;
          /* ScatterViewItem svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
            if (svi != null)
            {
                svi.Visibility = Visibility.Visible;
            }*/
        }

        private void Scatter_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            if ((e.Cursor.CurrentTarget != scatterBottom || e.Cursor.CurrentTarget != scatterTop || e.Cursor.CurrentTarget != scatterRight || e.Cursor.CurrentTarget != scatterLeft) && e.Cursor.Effects == DragDropEffects.Move)
            {
                //ScatterItemsTop.Remove(e.Cursor.Data as PhotoData);
        
                e.Handled = true;
            }
        }

        private void Scatter_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData photo=(PhotoData)e.Cursor.Data;
            PhotoData clonedPhoto=new PhotoData(photo.Source, photo.Caption, photo.Price);
            // If it isn't already on the ScatterView, add it to the source collection.
           
             ScatterViewItem svi;
            if (e.Cursor.CurrentTarget == scatterBottom)
            {
                ScatterItemsBottom.Add(clonedPhoto);
                svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterBottom);
                svi.Orientation = e.Cursor.GetOrientation(scatterBottom);

            }
            else if (e.Cursor.CurrentTarget == scatterTop)
            {
                ScatterItemsTop.Add(clonedPhoto);
                svi = scatterTop.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterTop);
                svi.Orientation = e.Cursor.GetOrientation(scatterTop);
            }
            else if (e.Cursor.CurrentTarget == scatterLeft)
            {
                ScatterItemsLeft.Add(clonedPhoto);
                svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterLeft);
                svi.Orientation = e.Cursor.GetOrientation(scatterLeft);
            }
            else 
            {
                ScatterItemsRight.Add(clonedPhoto);
                svi = scatterRight.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterRight);
                svi.Orientation = e.Cursor.GetOrientation(scatterRight);
            }

            // Get the ScatterViewItem that Scatter automatically generated.
         
            svi.Visibility = System.Windows.Visibility.Visible;
            svi.Width = 150;
            svi.Height = 150;
            svi.Background = Brushes.Transparent;

            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                svi.Loaded -= loadedEventHandler;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
                ssc = svi.Template.FindName("shadow", svi) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc.Visibility = Visibility.Hidden;
            });
            svi.Loaded += loadedEventHandler;


            // Setting e.Handle to true ensures that default behavior is not performed.
            e.Handled = true;
        }

        private void ListBox_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement findSource = e.OriginalSource as FrameworkElement;
            SurfaceListBoxItem draggedElement = null;

            // Find the SurfaceListBoxItem object that is being touched.
            while (draggedElement == null && findSource != null)
            {
                if ((draggedElement = findSource as SurfaceListBoxItem) == null)
                {
                    findSource = VisualTreeHelper.GetParent(findSource) as FrameworkElement;
                }
            }

            if (draggedElement == null)
            {
                return;
            }

            PhotoData data = draggedElement.Content as PhotoData;

            // Create the cursor visual
            ContentControl cursorVisual = new ContentControl()
            {
                Content = draggedElement.DataContext,
                Style = FindResource("HamburgerCursorStyle") as Style
            };

            // Create a list of input devices. Add the touches that
            // are currently captured within the dragged element and
            // the current touch (if it isn't already in the list).
            List<InputDevice> devices = new List<InputDevice>();
            devices.Add(e.TouchDevice);
            foreach (TouchDevice touch in draggedElement.TouchesCapturedWithin)
            {
                if (touch != e.TouchDevice)
                {
                    devices.Add(touch);
                }
            }

            // Get the drag source object
            ItemsControl dragSource = ItemsControl.ItemsControlFromItemContainer(draggedElement);

            SurfaceDragDrop.BeginDragDrop(
                dragSource,
                draggedElement,
                cursorVisual,
                draggedElement.DataContext,
                devices,
                DragDropEffects.Move);

            // Prevents the default touch behavior from happening and disrupting our code.
            e.Handled = true;
        }

        private void ListBox_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            

        }

        private void ListBox_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            if (e.Cursor.CurrentTarget != ListBox && e.Cursor.Effects == DragDropEffects.Move)
            {
                e.Handled = true;
            }
        }

        private void ListBox_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            // Setting e.Handle to true ensures that default behavior is not performed.
            e.Handled = true;
        }

        void SurfaceWindow1_TouchEnter_left(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Add("Left", c.GetTagData().Value);
                scatterLeft.Visibility = Visibility.Visible;
                Place_tag_left.Visibility = Visibility.Collapsed;
                //Label with the train info on top of the zone
            }
        }

        void SurfaceWindow1_TouchEnter_down(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Add("Down", c.GetTagData().Value);
                scatterBottom.Visibility = Visibility.Visible;
                Place_tag_down.Visibility = Visibility.Collapsed;
            }
        }

        void SurfaceWindow1_TouchEnter_up(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Add("Up", c.GetTagData().Value);
                scatterTop.Visibility = Visibility.Visible;
                Place_tag_up.Visibility = Visibility.Collapsed;
            }
        }

        void SurfaceWindow1_TouchEnter_right(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Add("Right", c.GetTagData().Value);
                scatterRight.Visibility = Visibility.Visible;
                Place_tag_right.Visibility = Visibility.Collapsed;
            }
        }

        void SurfaceWindow1_TouchLeave_right(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Remove("Right");
                scatterRight.Visibility = Visibility.Collapsed;
                Place_tag_right.Visibility = Visibility.Visible;
            }
        }

        void SurfaceWindow1_TouchLeave_left(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Remove("Left");
                scatterLeft.Visibility = Visibility.Collapsed;
                Place_tag_left.Visibility = Visibility.Visible;
            }
        }

        void SurfaceWindow1_TouchLeave_up(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Remove("Up");
                scatterTop.Visibility = Visibility.Collapsed;
                Place_tag_up.Visibility = Visibility.Visible;
            }
        }

        void SurfaceWindow1_TouchLeave_down(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                TabTags.Remove("Down");
                scatterBottom.Visibility = Visibility.Collapsed;
                Place_tag_down.Visibility = Visibility.Visible;
            }
        }

    }
}