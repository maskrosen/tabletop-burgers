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

        private double bottomPrice = 0;
        private double topPrice = 0;
        private double leftPrice = 0;
        private double rightPrice = 0;

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

            scatterRight.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_right);
            scatterLeft.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_left);
            scatterTop.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_up);
            scatterBottom.TouchLeave += new EventHandler<TouchEventArgs>(SurfaceWindow1_TouchLeave_down);

            Make_menu_down.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_down);
            Make_menu_up.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_up);
            Make_menu_left.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_left);
            Make_menu_right.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_right);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;

            LibraryItemsLeft.Add(new PhotoData("Images/BottomBreadTS.png", "Bottom Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/TopBreadTS.png", "Top Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/BrawnBreadTS.png", "Bottom Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/BrawonBreadTS.png", "Top Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/BreadWithSemsonTS.png", "Bottom Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/TopBreadWithSemsonTS.png", "Top Bread", 10));
            LibraryItemsLeft.Add(new PhotoData("Images/FrenchFriseTS.png", "French Fries", 15));
            LibraryItemsLeft.Add(new PhotoData("Images/FrenchFriseWithMeat.png", "French Fries with meat", 20));
            LibraryItemsLeft.Add(new PhotoData("Images/OnionFries.png", "Onion Fries", 15));
            LibraryItemsLeft.Add(new PhotoData("Images/WedgeFries.png", "Wedge Fries", 15));

            LibraryItemsBottom.Add(new PhotoData("Images/CucumberTS.png", "Cucumber", 5));
            LibraryItemsBottom.Add(new PhotoData("Images/TomatoSliceTS.png", "Tomato", 3));
            LibraryItemsBottom.Add(new PhotoData("Images/LuttesTS.png", "Lettuce", 2));
            LibraryItemsBottom.Add(new PhotoData("Images/OnionTS.png", "Onions", 3));
            LibraryItemsBottom.Add(new PhotoData("Images/Onion.png", "Onions 2", 3));
            LibraryItemsBottom.Add(new PhotoData("Images/MashroomTS.png", "Mushroom", 3));
            LibraryItemsBottom.Add(new PhotoData("Images/OlivesTS.png", "Olives", 5));
            LibraryItemsBottom.Add(new PhotoData("Images/PepearTS.png", "Bell pepper", 5));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot.png", "Carrot", 4));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot2.png", "Carrot 2", 4));
            LibraryItemsBottom.Add(new PhotoData("Images/CeaserSalaTS.png", "Ceasar Salad", 70));
            LibraryItemsBottom.Add(new PhotoData("Images/FruitSaladTS.png", "Fruit Salad", 70));
            LibraryItemsBottom.Add(new PhotoData("Images/GreekSaladTS.png", "Greek Salad", 70));
            LibraryItemsBottom.Add(new PhotoData("Images/shrimpSaladTS.png", "Shrimp Salad", 70));
            LibraryItemsBottom.Add(new PhotoData("Images/cabbage.png", "Cabbage", 4));
            LibraryItemsBottom.Add(new PhotoData("Images/ovocadoSlice.png", "Avocado", 4));
            LibraryItemsBottom.Add(new PhotoData("Images/papper.png", "Bell pepper", 4));
            LibraryItemsBottom.Add(new PhotoData("Images/SpiceTS.png", "Pickles", 4));

            LibraryItemsTop.Add(new PhotoData("Images/BlueDountsTS.png", "Blue Dounts", 20));
            LibraryItemsTop.Add(new PhotoData("Images/StrawberryDonutsTS.png", "Strawberry Dounts", 20));
            LibraryItemsTop.Add(new PhotoData("Images/ChocoDounts.png", "Chocolate Donut", 20));
            LibraryItemsTop.Add(new PhotoData("Images/SugerDonutsTS.png", "Sugar Donut", 20));
            LibraryItemsTop.Add(new PhotoData("Images/CaffeLatteTS.png", "Latte", 15));
            LibraryItemsTop.Add(new PhotoData("Images/CaffeeTS.png", "Coffee", 15));
            LibraryItemsTop.Add(new PhotoData("Images/chooIceCreamTS.png", "Chocolate ice cream", 10));
            LibraryItemsTop.Add(new PhotoData("Images/PistasioIcecreamTS.png", "Pistasio ice cream", 10));
            LibraryItemsTop.Add(new PhotoData("Images/StrawberyIceCream.png", "Strawberry ice cream", 10));
            LibraryItemsTop.Add(new PhotoData("Images/CinamonTS.png", "Cinnamon roll", 15));
            LibraryItemsTop.Add(new PhotoData("Images/cookies.png", "Cookie", 10));
            LibraryItemsTop.Add(new PhotoData("Images/CreamDountsTS.png", "Cream Donut", 20));
            LibraryItemsTop.Add(new PhotoData("Images/CupCake3TS.png", "Cupcake", 20));
            LibraryItemsTop.Add(new PhotoData("Images/GreenMuffenTS.png", "Muffin", 20));
            LibraryItemsTop.Add(new PhotoData("Images/VanilaCupCakeTS.jpg", "Vanilla Cupcake", 20));
            LibraryItemsTop.Add(new PhotoData("Images/Beer.png", "Beer", 20));
            LibraryItemsTop.Add(new PhotoData("Images/PEPSITS.png", "Pepsi", 20));
            LibraryItemsTop.Add(new PhotoData("Images/FantaTS.png", "Fanta", 20));
            LibraryItemsTop.Add(new PhotoData("Images/SpriteTS.png", "Sprite", 20));
            LibraryItemsTop.Add(new PhotoData("Images/OrangeTS.png", "Orange Juice", 20));
            LibraryItemsTop.Add(new PhotoData("Images/HallonSmoothie.png", "Hallon Smoothie", 20));
            LibraryItemsTop.Add(new PhotoData("Images/lemonSmootie.png", "Lemon Smoothie", 20));
            LibraryItemsTop.Add(new PhotoData("Images/Water.png", "Water", 20));

            LibraryItemsRight.Add(new PhotoData("Images/DoubleMeetTS.png", "Meat", 25));
            LibraryItemsRight.Add(new PhotoData("Images/EggTS.png", "Egg    ", 10));
            LibraryItemsRight.Add(new PhotoData("Images/Egg.png", "Egg 2   ", 10));
            LibraryItemsRight.Add(new PhotoData("Images/BaconTS.png", "Bacon    ", 10));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenBoxTS.png", "Fried Chicken", 40));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenFilletTS.png", "Chicken Fillet", 30));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenNuggetsTS.png", "Chicken Nuggets", 40));
            LibraryItemsRight.Add(new PhotoData("Images/DobleCheeseTS.png", "Double Cheese", 7));
            LibraryItemsRight.Add(new PhotoData("Images/CHesseTS.png", "Cheese", 7));
            LibraryItemsRight.Add(new PhotoData("Images/Ketchup.png", "Ketchup", 1));
            LibraryItemsRight.Add(new PhotoData("Images/SauceTS.png", "Sauce", 1));
            LibraryItemsRight.Add(new PhotoData("Images/HotDogTS.png", "Hot Dog", 30));
            LibraryItemsRight.Add(new PhotoData("Images/ShrimpTS.png", "Shrimps", 30));
            LibraryItemsRight.Add(new PhotoData("Images/KebabMeat.png", "Kebab meat", 20));
            LibraryItemsRight.Add(new PhotoData("Images/SalamonFiletTS.png", "Salmon Fillet", 25));

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
            if (e.Cursor.DragSource == scatterBottom)
            {
                bottomPrice -= data.Price;
                Price_label_down.Text = "Price " + bottomPrice;
            }

            if (e.Cursor.DragSource == scatterTop)
            {
                topPrice -= data.Price;
                Price_label_up.Text = "Price " + topPrice;
            }

            if (e.Cursor.DragSource == scatterLeft)
            {
                leftPrice -= data.Price;
                Price_label_left.Text = "Price " + leftPrice;
            }

            if (e.Cursor.DragSource == scatterRight)
            {
                rightPrice -= data.Price;
                Price_label_right.Text = "Price " + rightPrice;
            }
        }

        private void Scatter_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            if ((e.Cursor.CurrentTarget != scatterBottom || e.Cursor.CurrentTarget != scatterTop || e.Cursor.CurrentTarget != scatterRight || e.Cursor.CurrentTarget != scatterLeft) && e.Cursor.Effects == DragDropEffects.Move)
            {
                e.Handled = true;
               
            }

            if ((e.Cursor.DragSource == scatterBottom && e.Cursor.CurrentTarget != scatterBottom && e.Cursor.Effects == DragDropEffects.Move))
            {
                bottomPrice -= (e.Cursor.Data as PhotoData).Price;
                Price_label_down.Text = "Price " + bottomPrice;
            }

            if ((e.Cursor.DragSource == scatterTop && e.Cursor.CurrentTarget != scatterTop && e.Cursor.Effects == DragDropEffects.Move))
            {
                topPrice -= (e.Cursor.Data as PhotoData).Price;
                Price_label_up.Text = "Price " + topPrice;
            }
            if ((e.Cursor.DragSource == scatterLeft && e.Cursor.CurrentTarget != scatterLeft && e.Cursor.Effects == DragDropEffects.Move))
            {
                leftPrice -= (e.Cursor.Data as PhotoData).Price;
                Price_label_left.Text = "Price " + leftPrice;
            }
            if ((e.Cursor.DragSource == scatterRight && e.Cursor.CurrentTarget != scatterRight && e.Cursor.Effects == DragDropEffects.Move))
            {
                rightPrice -= (e.Cursor.Data as PhotoData).Price;
                Price_label_right.Text = "Price " + rightPrice;
            }
        }

        private void Scatter_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData photo=(PhotoData)e.Cursor.Data;
            PhotoData clonedPhoto=new PhotoData(photo.Source, photo.Caption, photo.Price);

             ScatterViewItem svi;
            if (e.Cursor.CurrentTarget == scatterBottom)
            {
                ScatterItemsBottom.Add(clonedPhoto);
                svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterBottom);
                svi.Orientation = e.Cursor.GetOrientation(scatterBottom);

                if (e.Cursor.DragSource != scatterBottom)
                {
                    bottomPrice += clonedPhoto.Price;
                    Price_label_down.Visibility = Visibility.Visible;
                    Price_label_down.Text = "Price " + bottomPrice;
                }

            }
            else if (e.Cursor.CurrentTarget == scatterTop)
            {
                ScatterItemsTop.Add(clonedPhoto);
                svi = scatterTop.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterTop);
                svi.Orientation = e.Cursor.GetOrientation(scatterTop);

                if (e.Cursor.DragSource != scatterTop)
                {
                    topPrice += clonedPhoto.Price;
                    Price_label_up.Visibility = Visibility.Visible;
                    Price_label_up.Text = "Price " + topPrice;
                }
            }
            else if (e.Cursor.CurrentTarget == scatterLeft)
            {
                ScatterItemsLeft.Add(clonedPhoto);
                svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterLeft);
                svi.Orientation = e.Cursor.GetOrientation(scatterLeft);

                if (e.Cursor.DragSource != scatterLeft)
                {
                    leftPrice += clonedPhoto.Price;
                    Price_label_left.Visibility = Visibility.Visible;
                    Price_label_left.Text = "Price " + leftPrice;
                }

            }
            else 
            {
                ScatterItemsRight.Add(clonedPhoto);
                svi = scatterRight.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Center = e.Cursor.GetPosition(scatterRight);
                svi.Orientation = e.Cursor.GetOrientation(scatterRight);

                if (e.Cursor.DragSource != scatterRight)
                {
                    rightPrice += clonedPhoto.Price;
                    Price_label_right.Visibility = Visibility.Visible;
                    Price_label_right.Text = "Price " + rightPrice;
                }
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
                long tagNumber = c.GetTagData().Value;
                if (TagItems.ContainsKey(tagNumber))
                {
                    Place_tag_left.Visibility = Visibility.Collapsed;
                    Tag tag = TagItems[tagNumber];
                    if (tag.orderPlaced)
                    {
                        Order_placed_left.Visibility = Visibility.Visible;
                        String minute;
                        if (tag.timeLeft == 1)
                        {
                            minute = " minute";
                        }
                        else
                        {
                            minute = " minutes";
                        }
                        Order_placed_left.Text = "ORDER PLACED\n Your order is being prepared\n Will be ready in " + tag.timeLeft + minute;
                    }
                    else
                    {
                        scatterLeft.Visibility = Visibility.Visible;
                        Train_label_left.Visibility = Visibility.Visible;
                        Train_label_left.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + tag.track;
                        Make_menu_left.Visibility = Visibility.Visible;

                    }
                }
            }
        }

        void SurfaceWindow1_TouchEnter_down(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                long tagNumber = c.GetTagData().Value;
                if (TagItems.ContainsKey(tagNumber))
                {
                    Place_tag_down.Visibility = Visibility.Collapsed;
                    Tag tag = TagItems[tagNumber];
                    if (tag.orderPlaced)
                    {
                        String minute;
                        if (tag.timeLeft == 1)
                        {
                            minute = " minute";
                        }
                        else
                        {
                            minute = " minutes";
                        }
                        Order_placed_down.Visibility = Visibility.Visible;
                        Order_placed_down.Text = "ORDER PLACED\n Your order is being prepared\n Will be ready in " + tag.timeLeft + minute;
                    }
                    else
                    {
                        scatterBottom.Visibility = Visibility.Visible;
                        Train_label_down.Visibility = Visibility.Visible;
                        Train_label_down.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + tag.track;
                        Make_menu_down.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        void SurfaceWindow1_TouchEnter_up(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                long tagNumber = c.GetTagData().Value;
                if (TagItems.ContainsKey(tagNumber))
                {
                    Place_tag_up.Visibility = Visibility.Collapsed;
                    Tag tag = TagItems[tagNumber];
                    if (tag.orderPlaced)
                    {
                        String minute;
                        if (tag.timeLeft == 1)
                        {
                            minute = " minute";
                        }
                        else
                        {
                            minute = " minutes";
                        }
                        Order_placed_up.Visibility = Visibility.Visible;
                        Order_placed_up.Text = "ORDER PLACED\n Your order is being prepared\n Will be ready in " + tag.timeLeft + minute;
                    }
                    else
                    {
                        scatterTop.Visibility = Visibility.Visible;
                        Train_label_up.Visibility = Visibility.Visible;
                        Train_label_up.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + tag.track;
                        Make_menu_up.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        void SurfaceWindow1_TouchEnter_right(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                long tagNumber = c.GetTagData().Value;

                if (TagItems.ContainsKey(tagNumber))
                {
                    Place_tag_right.Visibility = Visibility.Collapsed;
                    Tag tag = TagItems[tagNumber];
                    if (tag.orderPlaced)
                    {
                        String minute;
                        if (tag.timeLeft == 1)
                        {
                            minute = " minute";
                        }
                        else
                        {
                            minute = " minutes";
                        }
                        Order_placed_right.Visibility = Visibility.Visible;
                        Order_placed_right.Text = "ORDER PLACED\n Your order is being prepared\n Will be ready in " + tag.timeLeft + minute;
                    }
                    else
                    {
                        scatterRight.Visibility = Visibility.Visible;
                        Train_label_right.Visibility = Visibility.Visible;
                        Train_label_right.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + tag.track;
                        Make_menu_right.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        void SurfaceWindow1_TouchLeave_right(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                scatterRight.Visibility = Visibility.Collapsed;
                Place_tag_right.Visibility = Visibility.Visible;
                Train_label_right.Visibility = Visibility.Hidden;
                Make_menu_right.Visibility = Visibility.Hidden;
            }
        }

        void SurfaceWindow1_TouchLeave_left(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                scatterLeft.Visibility = Visibility.Collapsed;
                Place_tag_left.Visibility = Visibility.Visible;
                Train_label_left.Visibility = Visibility.Hidden;
                Make_menu_left.Visibility = Visibility.Hidden;
            }
        }

        void SurfaceWindow1_TouchLeave_up(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                scatterTop.Visibility = Visibility.Collapsed;
                Place_tag_up.Visibility = Visibility.Visible;
                Train_label_up.Visibility = Visibility.Hidden;
                Make_menu_up.Visibility = Visibility.Hidden;
            }
        }

        void SurfaceWindow1_TouchLeave_down(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                scatterBottom.Visibility = Visibility.Collapsed;
                Place_tag_down.Visibility = Visibility.Visible;
                Train_label_down.Visibility = Visibility.Hidden;
                Make_menu_down.Visibility = Visibility.Hidden;
            }
        }

        void MakeMenu_TouchDown_down(object sender, TouchEventArgs e)
        {
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20);

            //Add to total price!
            bottomPrice += 35;
            Price_label_down.Text = "Price " + bottomPrice;

            ScatterItemsBottom.Add(friesPhoto);
            ScatterItemsBottom.Add(drinkPhoto);

             ScatterViewItem svi1 = scatterBottom.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
             svi1.Orientation = 0;

             ScatterViewItem svi2 = scatterBottom.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
             svi2.Orientation = 0;

             svi1.Background = Brushes.Transparent;
             svi2.Background = Brushes.Transparent;

             RoutedEventHandler loadedEventHandler = null;
             loadedEventHandler = new RoutedEventHandler(delegate
             {
                 svi1.Loaded -= loadedEventHandler;
                 svi2.Loaded -= loadedEventHandler;
                 Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
                 ssc = svi1.Template.FindName("shadow", svi1) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                 ssc.Visibility = Visibility.Hidden;
                 Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc2;
                 ssc2 = svi2.Template.FindName("shadow", svi2) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                 ssc2.Visibility = Visibility.Hidden;
             });
             svi1.Loaded += loadedEventHandler;
             svi2.Loaded += loadedEventHandler;
        }

        void MakeMenu_TouchDown_up(object sender, TouchEventArgs e)
        {
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20);

            //Add to total price!
            topPrice += 35;
            Price_label_up.Text = "Price " + topPrice;


            ScatterItemsTop.Add(friesPhoto);
            ScatterItemsTop.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterTop.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 180;

            ScatterViewItem svi2 = scatterTop.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
            svi2.Orientation = 180;

            svi1.Background = Brushes.Transparent;
            svi2.Background = Brushes.Transparent;

            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                svi1.Loaded -= loadedEventHandler;
                svi2.Loaded -= loadedEventHandler;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
                ssc = svi1.Template.FindName("shadow", svi1) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc.Visibility = Visibility.Hidden;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc2;
                ssc2 = svi2.Template.FindName("shadow", svi2) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc2.Visibility = Visibility.Hidden;
            });
            svi1.Loaded += loadedEventHandler;
            svi2.Loaded += loadedEventHandler;
        }

        void MakeMenu_TouchDown_left(object sender, TouchEventArgs e)
        {
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20);

            //Add to total price!

            leftPrice += 35;
            Price_label_left.Text = "Price " + leftPrice;


            ScatterItemsLeft.Add(friesPhoto);
            ScatterItemsLeft.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterLeft.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 90;

            ScatterViewItem svi2 = scatterLeft.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
            svi2.Orientation = 90;

            svi1.Background = Brushes.Transparent;
            svi2.Background = Brushes.Transparent;

            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                svi1.Loaded -= loadedEventHandler;
                svi2.Loaded -= loadedEventHandler;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
                ssc = svi1.Template.FindName("shadow", svi1) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc.Visibility = Visibility.Hidden;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc2;
                ssc2 = svi2.Template.FindName("shadow", svi2) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc2.Visibility = Visibility.Hidden;
            });
            svi1.Loaded += loadedEventHandler;
            svi2.Loaded += loadedEventHandler;
        }

        void MakeMenu_TouchDown_right(object sender, TouchEventArgs e)
        {
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20);

            //Add to total price!

            rightPrice += 35;
            Price_label_right.Text = "Price " + rightPrice;

            ScatterItemsRight.Add(friesPhoto);
            ScatterItemsRight.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterRight.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 270;

            ScatterViewItem svi2 = scatterRight.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
            svi2.Orientation = 270;

            svi1.Background = Brushes.Transparent;
            svi2.Background = Brushes.Transparent;

            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                svi1.Loaded -= loadedEventHandler;
                svi2.Loaded -= loadedEventHandler;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc;
                ssc = svi1.Template.FindName("shadow", svi1) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc.Visibility = Visibility.Hidden;
                Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome ssc2;
                ssc2 = svi2.Template.FindName("shadow", svi2) as Microsoft.Surface.Presentation.Generic.SurfaceShadowChrome;
                ssc2.Visibility = Visibility.Hidden;
            });
            svi1.Loaded += loadedEventHandler;
            svi2.Loaded += loadedEventHandler;
        }

    }
}