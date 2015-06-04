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

        private ObservableCollection<PhotoData> auxiliarItemsTop;
        private ObservableCollection<PhotoData> auxiliarItemsBottom;
        private ObservableCollection<PhotoData> auxiliarItemsRight;
        private ObservableCollection<PhotoData> auxiliarItemsLeft;

        EventHandler<TouchEventArgs> clear_event_right;
        EventHandler<TouchEventArgs> clear_event_left;
        EventHandler<TouchEventArgs> clear_event_up;
        EventHandler<TouchEventArgs> clear_event_down;

        EventHandler<TouchEventArgs> undo_event_right;
        EventHandler<TouchEventArgs> undo_event_left;
        EventHandler<TouchEventArgs> undo_event_up;
        EventHandler<TouchEventArgs> undo_event_down;

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

        public ObservableCollection<PhotoData> AuxiliarItemsLeft
        {
            get
            {
                if (auxiliarItemsLeft == null)
                {
                    auxiliarItemsLeft = new ObservableCollection<PhotoData>();
                }

                return auxiliarItemsLeft;
            }
        }

        public ObservableCollection<PhotoData> AuxiliarItemsRight
        {
            get
            {
                if (auxiliarItemsRight == null)
                {
                    auxiliarItemsRight = new ObservableCollection<PhotoData>();
                }

                return auxiliarItemsRight;
            }
        }

        public ObservableCollection<PhotoData> AuxiliarItemsTop
        {
            get
            {
                if (auxiliarItemsTop == null)
                {
                    auxiliarItemsTop = new ObservableCollection<PhotoData>();
                }

                return auxiliarItemsTop;
            }
        }

        public ObservableCollection<PhotoData> AuxiliarItemsBottom
        {
            get
            {
                if (auxiliarItemsBottom == null)
                {
                    auxiliarItemsBottom = new ObservableCollection<PhotoData>();
                }

                return auxiliarItemsBottom;
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

            Order_placed_left.TouchLeave += new EventHandler<TouchEventArgs>(OrderPlaced_touchLeave_left);
            Order_placed_right.TouchLeave += new EventHandler<TouchEventArgs>(OrderPlaced_touchLeave_right);
            Order_placed_up.TouchLeave += new EventHandler<TouchEventArgs>(OrderPlaced_touchLeave_up);
            Order_placed_down.TouchLeave += new EventHandler<TouchEventArgs>(OrderPlaced_touchLeave_down);

            Make_menu_down.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_down);
            Make_menu_up.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_up);
            Make_menu_left.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_left);
            Make_menu_right.TouchDown += new EventHandler<TouchEventArgs>(MakeMenu_TouchDown_right);

            Clonefront_down.TouchDown += new EventHandler<TouchEventArgs>(Clonefront_TouchDown_down);
            Clonefront_left.TouchDown += new EventHandler<TouchEventArgs>(Clonefront_TouchDown_left);
            Clonefront_right.TouchDown += new EventHandler<TouchEventArgs>(Clonefront_TouchDown_right);
            Clonefront_up.TouchDown += new EventHandler<TouchEventArgs>(Clonefront_TouchDown_up);

            Cloneleft_down.TouchDown += new EventHandler<TouchEventArgs>(Cloneleft_TouchDown_down);
            Cloneleft_left.TouchDown += new EventHandler<TouchEventArgs>(Cloneleft_TouchDown_left);
            Cloneleft_right.TouchDown += new EventHandler<TouchEventArgs>(Cloneleft_TouchDown_right);
            Cloneleft_up.TouchDown += new EventHandler<TouchEventArgs>(Cloneleft_TouchDown_up);

            Cloneright_down.TouchDown += new EventHandler<TouchEventArgs>(Cloneright_TouchDown_down);
            Cloneright_left.TouchDown += new EventHandler<TouchEventArgs>(Cloneright_TouchDown_left);
            Cloneright_right.TouchDown += new EventHandler<TouchEventArgs>(Cloneright_TouchDown_right);
            Cloneright_up.TouchDown += new EventHandler<TouchEventArgs>(Cloneright_TouchDown_up); 

            clear_event_right= new EventHandler<TouchEventArgs>(Clear_TouchDown_right);
            clear_event_left = new EventHandler<TouchEventArgs>(Clear_TouchDown_left);
            clear_event_up = new EventHandler<TouchEventArgs>(Clear_TouchDown_up);
            clear_event_down = new EventHandler<TouchEventArgs>(Clear_TouchDown_down);

            Clear_right.TouchDown += clear_event_right;
            Clear_up.TouchDown += clear_event_up;
            Clear_down.TouchDown += clear_event_down;
            Clear_left.TouchDown += clear_event_left;

            undo_event_right = new EventHandler<TouchEventArgs>(Undo_TouchDown_right);
            undo_event_left = new EventHandler<TouchEventArgs>(Undo_TouchDown_left);
            undo_event_up = new EventHandler<TouchEventArgs>(Undo_TouchDown_up);
            undo_event_down = new EventHandler<TouchEventArgs>(Undo_TouchDown_down);

            auxiliarItemsLeft = new ObservableCollection<PhotoData>();
            auxiliarItemsRight = new ObservableCollection<PhotoData>();
            auxiliarItemsTop = new ObservableCollection<PhotoData>();
            auxiliarItemsBottom = new ObservableCollection<PhotoData>();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;

            LibraryItemsLeft.Add(new PhotoData("Images/BottomBreadTS.png", "Bottom Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/TopBreadTS.png", "Top Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/BrawnBreadTS.png", "Bottom Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/BrawonBreadTS.png", "Top Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/BreadWithSemsonTS.png", "Bottom Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/TopBreadWithSemsonTS.png", "Top Bread", 10, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/FrenchFriseTS.png", "French Fries", 1, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/FrenchFriseWithMeat.png", "French Fries with meat", 20, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/OnionFries.png", "Onion Rings", 15, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/onion-thing.png", "Onion Rings 2", 15, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/WedgeFries.png", "Wedge Fries", 15, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/nachos.png", "Nachos", 15, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/popcorn.png", "Popcorn", 15, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/pizza.png", "Pizza", 55, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/breakfast.png", "Breakfast", 35, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/pancakes2.png", "Breakfast", 35, 90));
            LibraryItemsLeft.Add(new PhotoData("Images/BottomBreadTS.png", "Bottom Bread", 10, 90));

            LibraryItemsBottom.Add(new PhotoData("Images/CucumberTS.png", "Cucumber", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/TomatoSliceTS.png", "Tomato", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/LuttesTS.png", "Lettuce", 2, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/OnionTS.png", "Onions", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/Onion.png", "Onions 2", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/MashroomTS.png", "Mushroom", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/OlivesTS.png", "Olives", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/PepearTS.png", "Bell pepper", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot.png", "Carrot", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot2.png", "Carrot 2", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/CeaserSalaTS.png", "Ceasar Salad", 70, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/FruitSaladTS.png", "Fruit Salad", 70, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/GreekSaladTS.png", "Greek Salad", 70, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/shrimpSaladTS.png", "Shrimp Salad", 70, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/salad.png", "Salad", 40, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/cabbage.png", "Cabbage", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/ovocadoSlice.png", "Avocado", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/papper.png", "Bell pepper", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/SpiceTS.png", "Pickles", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/Corn.png", "Corn", 10, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/CornCup.png", "Corn in cup", 10, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/GreenOnion.png", "Chives", 10, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/CucumberTS.png", "Cucumber", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/TomatoSliceTS.png", "Tomato", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/LuttesTS.png", "Lettuce", 2, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/OnionTS.png", "Onions", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/Onion.png", "Onions 2", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/MashroomTS.png", "Mushroom", 3, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/OlivesTS.png", "Olives", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/PepearTS.png", "Bell pepper", 5, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot.png", "Carrot", 4, 0));
            LibraryItemsBottom.Add(new PhotoData("Images/carrot2.png", "Carrot 2", 4, 0));

            LibraryItemsTop.Add(new PhotoData("Images/BlueDountsTS.png", "Blue Dounts", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/StrawberryDonutsTS.png", "Strawberry Dounts", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/ChocoDounts.png", "Chocolate Donut", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/SugerDonutsTS.png", "Sugar Donut", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CreamDountsTS.png", "Cream Donut", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CaffeLatteTS.png", "Latte", 15, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CaffeeTS.png", "Coffee", 15, 180));
            LibraryItemsTop.Add(new PhotoData("Images/chooIceCreamTS.png", "Chocolate ice cream", 10, 180));
            LibraryItemsTop.Add(new PhotoData("Images/PistasioIcecreamTS.png", "Pistasio ice cream", 10, 180));
            LibraryItemsTop.Add(new PhotoData("Images/StrawberyIceCream.png", "Strawberry ice cream", 10, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CinamonTS.png", "Cinnamon roll", 15, 180));
            LibraryItemsTop.Add(new PhotoData("Images/cookies.png", "Cookie", 10, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CupCake3TS.png", "Cupcake", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/GreenMuffenTS.png", "Muffin", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/MuffenWithReadBerries.png", "Muffin with red berries", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/StwbaryChocoletMuffen.png", "Strawberry chocolate muffin", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/cheesecake.png", "Cheesecake", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/chocolate.png", "Chocolate", 10, 180));
            LibraryItemsTop.Add(new PhotoData("Images/feature_3yoghurt1.png", "Frozen Yoghurt", 25, 180));
            LibraryItemsTop.Add(new PhotoData("Images/Beer.png", "Beer", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/PEPSITS.png", "Pepsi", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/FantaTS.png", "Fanta", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/SpriteTS.png", "Sprite", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/OrangeTS.png", "Orange Juice", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/HallonSmoothie.png", "Hallon Smoothie", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/lemonSmootie.png", "Lemon Smoothie", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/Water.png", "Water", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/BlueDountsTS.png", "Blue Dounts", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/StrawberryDonutsTS.png", "Strawberry Dounts", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/ChocoDounts.png", "Chocolate Donut", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/SugerDonutsTS.png", "Sugar Donut", 20, 180));
            LibraryItemsTop.Add(new PhotoData("Images/CreamDountsTS.png", "Cream Donut", 20, 180));

            LibraryItemsRight.Add(new PhotoData("Images/DoubleMeetTS.png", "Meat", 25, 270));
            LibraryItemsRight.Add(new PhotoData("Images/EggTS.png", "Egg    ", 10, 270));
            LibraryItemsRight.Add(new PhotoData("Images/Egg.png", "Egg 2   ", 10, 270));
            LibraryItemsRight.Add(new PhotoData("Images/BaconTS.png", "Bacon    ", 10, 270));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenBoxTS.png", "Fried Chicken", 40, 270));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenFilletTS.png", "Chicken Fillet", 30, 270));
            LibraryItemsRight.Add(new PhotoData("Images/CheckenNuggetsTS.png", "Chicken Nuggets", 40, 270));
            LibraryItemsRight.Add(new PhotoData("Images/DobleCheeseTS.png", "Double Cheese", 7, 270));
            LibraryItemsRight.Add(new PhotoData("Images/CHesseTS.png", "Cheese", 7, 270));
            LibraryItemsRight.Add(new PhotoData("Images/Ketchup.png", "Ketchup", 1, 270));
            LibraryItemsRight.Add(new PhotoData("Images/SauceTS.png", "Sauce", 1, 270));
            LibraryItemsRight.Add(new PhotoData("Images/HotDogTS.png", "Hot Dog", 30, 270));
            LibraryItemsRight.Add(new PhotoData("Images/ShrimpTS.png", "Shrimps", 30, 270));
            LibraryItemsRight.Add(new PhotoData("Images/KebabMeat.png", "Kebab meat", 20, 270));
            LibraryItemsRight.Add(new PhotoData("Images/SalamonFiletTS.png", "Salmon Fillet", 25, 270));
            LibraryItemsRight.Add(new PhotoData("Images/Falafel.png", "Falafel", 25, 270));
            LibraryItemsRight.Add(new PhotoData("Images/DoubleMeetTS.png", "Meat", 25, 270));
            LibraryItemsRight.Add(new PhotoData("Images/EggTS.png", "Egg    ", 10, 270));
            LibraryItemsRight.Add(new PhotoData("Images/Egg.png", "Egg 2   ", 10, 270));
            LibraryItemsRight.Add(new PhotoData("Images/BaconTS.png", "Bacon    ", 10, 270));

            TagItems.Add(1, new Tag(1, 387, "Stockholm C", new DateTime(2015, 6, 4, 17, 0, 0), -1, false, -1));
            TagItems.Add(2, new Tag(2, 7843, "Malmö", new DateTime(2015, 6, 4, 16, 15, 0), 8, false, -1));
            TagItems.Add(3, new Tag(3, 987, "Uppsala", new DateTime(2015, 5, 20, 12, 35, 0), 3, false, -1));
            TagItems.Add(4, new Tag(2, 7843, "Malmö", new DateTime(2015, 6, 4, 16, 15, 0), 8, false, -1));
            TagItems.Add(5, new Tag(5, 387, "Stockholm C", new DateTime(2015, 6, 4, 17, 0, 0), -1, false, -1));
            TagItems.Add(6, new Tag(6, 387, "Stockholm C", new DateTime(2015, 6, 4, 17, 0, 0), -1, true, 5));

            BurgerItems.Add(new PhotoData("Images/Burger1TS.png", "King burger", 70, 0));
            BurgerItems.Add(new PhotoData("Images/Burger2TS.png", "Popular choice", 67, 270));
            BurgerItems.Add(new PhotoData("Images/Burger3.png", "Ready from the kitchen", 62, 180));
            BurgerItems.Add(new PhotoData("Images/Burger4.png", "Grilled texan", 75, 90));
            BurgerItems.Add(new PhotoData("Images/FinalBurgerTS.png", "Deluxe cheddar", 80, 0));
            BurgerItems.Add(new PhotoData("Images/simple-burger.png", "Basic burger", 50, 90));
            BurgerItems.Add(new PhotoData("Images/hamicon-09.png", "Basic burger", 45, 180));

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
                ScatterItemsBottom.Remove(data);
            }

            if (e.Cursor.DragSource == scatterTop)
            {
                topPrice -= data.Price;
                Price_label_up.Text = "Price " + topPrice;
                ScatterItemsTop.Remove(data);
            }

            if (e.Cursor.DragSource == scatterLeft)
            {
                leftPrice -= data.Price;
                Price_label_left.Text = "Price " + leftPrice;
                ScatterItemsLeft.Remove(data);
            }

            if (e.Cursor.DragSource == scatterRight)
            {
                rightPrice -= data.Price;
                Price_label_right.Text = "Price " + rightPrice;
                ScatterItemsRight.Remove(data);
            }
        }

        private void Scatter_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            if ((e.Cursor.CurrentTarget != scatterBottom || e.Cursor.CurrentTarget != scatterTop || e.Cursor.CurrentTarget != scatterRight || e.Cursor.CurrentTarget != scatterLeft) && e.Cursor.Effects == DragDropEffects.Move)
            {
                e.Handled = true;
               
            }
            PhotoData data = (e.Cursor.Data as PhotoData);

            if ((e.Cursor.DragSource == scatterBottom && e.Cursor.CurrentTarget != scatterBottom && e.Cursor.Effects == DragDropEffects.Move))
            {
                bottomPrice -= data.Price;
                Price_label_down.Text = "Price " + bottomPrice;
                ScatterItemsBottom.Remove(data);
            }

            if ((e.Cursor.DragSource == scatterTop && e.Cursor.CurrentTarget != scatterTop && e.Cursor.Effects == DragDropEffects.Move))
            {
                topPrice -= data.Price;
                Price_label_up.Text = "Price " + topPrice;
                ScatterItemsTop.Remove(data);
            }
            if ((e.Cursor.DragSource == scatterLeft && e.Cursor.CurrentTarget != scatterLeft && e.Cursor.Effects == DragDropEffects.Move))
            {
                leftPrice -= data.Price;
                Price_label_left.Text = "Price " + leftPrice;
                ScatterItemsLeft.Remove(data);
            }
            if ((e.Cursor.DragSource == scatterRight && e.Cursor.CurrentTarget != scatterRight && e.Cursor.Effects == DragDropEffects.Move))
            {
                rightPrice -= data.Price;
                Price_label_right.Text = "Price " + rightPrice;
                ScatterItemsRight.Remove(data);
            }
        }

        private void Scatter_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData photo=(PhotoData)e.Cursor.Data;
            PhotoData clonedPhoto=new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);

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
                ScatterItemsBottom.Remove(photo);

                while (auxiliarItemsBottom.Count() > 0)
                {
                    auxiliarItemsBottom.RemoveAt(0);
                }
                Clear_down.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
                Clear_down.TouchDown -= undo_event_down;
                Clear_down.TouchDown += clear_event_down;

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
                ScatterItemsTop.Remove(photo);
                while (auxiliarItemsTop.Count() > 0)
                {
                    auxiliarItemsTop.RemoveAt(0);
                }
                Clear_up.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
                Clear_up.TouchDown -= undo_event_up;
                Clear_up.TouchDown += clear_event_up;
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
                ScatterItemsLeft.Remove(photo);
                while (auxiliarItemsLeft.Count() > 0)
                {
                    auxiliarItemsLeft.RemoveAt(0);
                }
                Clear_left.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
                Clear_left.TouchDown -= undo_event_left;
                Clear_left.TouchDown += clear_event_left;
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
                ScatterItemsRight.Remove(photo);
                while (auxiliarItemsRight.Count() > 0)
                {
                    auxiliarItemsRight.RemoveAt(0);
                }
                Clear_right.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
                Clear_right.TouchDown -= undo_event_right;
                Clear_right.TouchDown += clear_event_right;
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
                    Price_label_left.Visibility = Visibility.Visible;
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
                        Price_label_left.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        String track = "not announced";
                        if (tag.track != -1)
                        {
                            track = tag.track.ToString();
                        }
                        scatterLeft.Visibility = Visibility.Visible;
                        Train_label_left.Visibility = Visibility.Visible;
                        Train_label_left.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + track;
                        LeftStack_left.Visibility = Visibility.Visible;
                        RightStack_left.Visibility = Visibility.Visible;

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
                    Price_label_down.Visibility = Visibility.Visible;
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
                        Price_label_down.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        String track = "not announced";
                        if (tag.track != -1)
                        {
                            track = tag.track.ToString();
                        }
                        scatterBottom.Visibility = Visibility.Visible;
                        Train_label_down.Visibility = Visibility.Visible;
                        Train_label_down.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + track;
                        LeftStack_down.Visibility = Visibility.Visible;
                        RightStack_down.Visibility = Visibility.Visible;
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
                    Price_label_up.Visibility = Visibility.Visible;
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
                        Price_label_up.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        String track = "not announced";
                        if (tag.track != -1)
                        {
                            track = tag.track.ToString();
                        }
                        scatterTop.Visibility = Visibility.Visible;
                        Train_label_up.Visibility = Visibility.Visible;
                        Train_label_up.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + track;
                        LeftStack_up.Visibility = Visibility.Visible;
                        RightStack_up.Visibility = Visibility.Visible;
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
                    Price_label_right.Visibility = Visibility.Visible;
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
                        Price_label_right.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        String track = "not announced";
                        if (tag.track != -1)
                        {
                            track = tag.track.ToString();
                        }
                        scatterRight.Visibility = Visibility.Visible;
                        Train_label_right.Visibility = Visibility.Visible;
                        Train_label_right.Text = "Train " + tag.trainNumber + " to " + tag.destination + " " + tag.time + " track " + track;
                        LeftStack_right.Visibility = Visibility.Visible;
                        RightStack_right.Visibility = Visibility.Visible;
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
                LeftStack_right.Visibility = Visibility.Hidden;
                RightStack_right.Visibility = Visibility.Hidden;
                Price_label_right.Visibility = Visibility.Hidden;
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
                LeftStack_left.Visibility = Visibility.Hidden;
                RightStack_left.Visibility = Visibility.Hidden;
                Price_label_left.Visibility = Visibility.Hidden;
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
                LeftStack_up.Visibility = Visibility.Hidden;
                RightStack_up.Visibility = Visibility.Hidden;
                Price_label_up.Visibility = Visibility.Hidden;
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
                LeftStack_down.Visibility = Visibility.Hidden;
                RightStack_down.Visibility = Visibility.Hidden;
                Price_label_down.Visibility = Visibility.Hidden;
            }
        }


        void OrderPlaced_touchLeave_left(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                Order_placed_left.Visibility = Visibility.Hidden;
                Place_tag_left.Visibility = Visibility.Visible;
            }
        }

        void OrderPlaced_touchLeave_right(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                Order_placed_right.Visibility = Visibility.Hidden;
                Place_tag_right.Visibility = Visibility.Visible;
            }
        }

        void OrderPlaced_touchLeave_down(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                Order_placed_down.Visibility = Visibility.Hidden;
                Place_tag_down.Visibility = Visibility.Visible;
            }
        }

        void OrderPlaced_touchLeave_up(object sender, TouchEventArgs e)
        {
            TouchDevice c = e.TouchDevice;

            if (c.GetIsTagRecognized() == true)
            {
                Order_placed_up.Visibility = Visibility.Hidden;
                Place_tag_up.Visibility = Visibility.Visible;
            }
        }
        void MakeMenu_TouchDown_down(object sender, TouchEventArgs e)
        {
            while (auxiliarItemsBottom.Count() > 0)
            {
                auxiliarItemsBottom.RemoveAt(0);
            }
            Clear_down.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_down.TouchDown -= undo_event_down;
            Clear_down.TouchDown += clear_event_down;
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15, 90);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20, 180);

            //Add to total price!
            bottomPrice += 35;
            Price_label_down.Text = "Price " + bottomPrice;

            ScatterItemsBottom.Add(friesPhoto);
            ScatterItemsBottom.Add(drinkPhoto);

             ScatterViewItem svi1 = scatterBottom.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
             svi1.Orientation = 270;

             ScatterViewItem svi2 = scatterBottom.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
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

        void MakeMenu_TouchDown_up(object sender, TouchEventArgs e)
        {
            while (auxiliarItemsTop.Count() > 0)
            {
                auxiliarItemsTop.RemoveAt(0);
            }
            Clear_up.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_up.TouchDown -= undo_event_up;
            Clear_up.TouchDown += clear_event_up;
            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15, 90);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20, 180);

            //Add to total price!
            topPrice += 35;
            Price_label_up.Text = "Price " + topPrice;


            ScatterItemsTop.Add(friesPhoto);
            ScatterItemsTop.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterTop.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 90;

            ScatterViewItem svi2 = scatterTop.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
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

        void MakeMenu_TouchDown_left(object sender, TouchEventArgs e)
        {
            while (auxiliarItemsLeft.Count() > 0)
            {
                auxiliarItemsLeft.RemoveAt(0);
            }
            Clear_left.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_left.TouchDown -= undo_event_left;
            Clear_left.TouchDown += clear_event_left;

            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15, 90);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20, 180);

            //Add to total price!

            leftPrice += 35;
            Price_label_left.Text = "Price " + leftPrice;


            ScatterItemsLeft.Add(friesPhoto);
            ScatterItemsLeft.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterLeft.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 0;

            ScatterViewItem svi2 = scatterLeft.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
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

        void MakeMenu_TouchDown_right(object sender, TouchEventArgs e)
        {
            while (auxiliarItemsRight.Count() > 0)
            {
                auxiliarItemsRight.RemoveAt(0);
            }
            Clear_right.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_right.TouchDown -= undo_event_right;
            Clear_right.TouchDown += clear_event_right;

            //Add fries and coke to the down scatterview
            PhotoData friesPhoto = new PhotoData("Images/FrenchFriseTS.png", "Fries", 15, 90);
            PhotoData drinkPhoto = new PhotoData("Images/PEPSITS.png", "Pepsi", 20, 180);

            //Add to total price!

            rightPrice += 35;
            Price_label_right.Text = "Price " + rightPrice;

            ScatterItemsRight.Add(friesPhoto);
            ScatterItemsRight.Add(drinkPhoto);

            ScatterViewItem svi1 = scatterRight.ItemContainerGenerator.ContainerFromItem(friesPhoto) as ScatterViewItem;
            svi1.Orientation = 180;

            ScatterViewItem svi2 = scatterRight.ItemContainerGenerator.ContainerFromItem(drinkPhoto) as ScatterViewItem;
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

        void Clear_TouchDown_up(object sender, TouchEventArgs e)
        {
            while (ScatterItemsTop.Count() > 0)
            {  
                auxiliarItemsTop.Add(ScatterItemsTop.First());
                ScatterItemsTop.RemoveAt(0);
            }
            topPrice = 0;
            Price_label_up.Text = "Price " + topPrice;
            Clear_up.Source = new BitmapImage(new Uri("Images/undo.png", UriKind.Relative));
            Clear_up.TouchDown -= clear_event_up;
            Clear_up.TouchDown += undo_event_up;
        }

        void Clear_TouchDown_down(object sender, TouchEventArgs e)
        {
            while (ScatterItemsBottom.Count() > 0)
            {
                auxiliarItemsBottom.Add(ScatterItemsBottom.First());
                ScatterItemsBottom.RemoveAt(0);
            }
            bottomPrice = 0;
            Price_label_down.Text = "Price " + bottomPrice;
            Clear_down.Source = new BitmapImage(new Uri("Images/undo.png", UriKind.Relative));
            Clear_down.TouchDown -= clear_event_down;
            Clear_down.TouchDown += undo_event_down;
        }

        void Clear_TouchDown_right(object sender, TouchEventArgs e)
        {
            while (ScatterItemsRight.Count() > 0)
            {
                auxiliarItemsRight.Add(ScatterItemsRight.First());
                ScatterItemsRight.RemoveAt(0);
            }
            rightPrice = 0;
            Price_label_right.Text = "Price " + rightPrice;
            Clear_right.Source = new BitmapImage(new Uri("Images/undo.png", UriKind.Relative));
            Clear_right.TouchDown -= clear_event_right;
            Clear_right.TouchDown += undo_event_right;
        }

        void Clear_TouchDown_left(object sender, TouchEventArgs e)
        {
            while (ScatterItemsLeft.Count() > 0)
            {
                auxiliarItemsLeft.Add(ScatterItemsLeft.First());
                ScatterItemsLeft.RemoveAt(0);
            }
            leftPrice = 0;
            Price_label_left.Text = "Price " + leftPrice;
            Clear_left.Source = new BitmapImage(new Uri("Images/undo.png", UriKind.Relative));
            Clear_left.TouchDown -= clear_event_left;
            Clear_left.TouchDown += undo_event_left;
        }

        void Undo_TouchDown_left(object sender, TouchEventArgs e)
        {
            Clear_left.TouchDown -= undo_event_left;
            for (int i = 0; i < AuxiliarItemsLeft.Count(); i++)
            {
                PhotoData data = auxiliarItemsLeft.ElementAt(i);
                scatterItemsLeft.Add(data);
                ScatterViewItem svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
                svi.Orientation = (90 - data.Angle) % 360;
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
            }

            while (auxiliarItemsLeft.Count() > 0)
            {
                auxiliarItemsLeft.RemoveAt(0);
            }

            leftPrice = 0;
            for (int i = 0; i < scatterItemsLeft.Count(); i++)
            {
                leftPrice += scatterItemsLeft.ElementAt(i).Price;
            }
            Price_label_left.Text = "Price " + leftPrice;
            Clear_left.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_left.TouchDown += clear_event_left;
        }

        void Undo_TouchDown_right(object sender, TouchEventArgs e)
        {
            Clear_right.TouchDown -= undo_event_right;
            for (int i = 0; i < AuxiliarItemsRight.Count(); i++)
            {
                PhotoData data = auxiliarItemsRight.ElementAt(i);
                scatterItemsRight.Add(data);
                ScatterViewItem svi = scatterRight.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
                svi.Orientation = (270 - data.Angle) % 360;
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
            }
            while (auxiliarItemsRight.Count() > 0)
            {
                auxiliarItemsRight.RemoveAt(0);
            }

            rightPrice = 0;
            for (int i = 0; i < scatterItemsRight.Count(); i++)
            {
                rightPrice += scatterItemsRight.ElementAt(i).Price;
            }
            Price_label_right.Text = "Price " + rightPrice;
            Clear_right.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_right.TouchDown += clear_event_right;
        }

        void Undo_TouchDown_up(object sender, TouchEventArgs e)
        {
            Clear_up.TouchDown -= undo_event_up;

            for (int i = 0; i < AuxiliarItemsTop.Count(); i++)
            {
                PhotoData data = auxiliarItemsTop.ElementAt(i);
                scatterItemsTop.Add(data);
                ScatterViewItem svi = scatterTop.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
                svi.Orientation = (180 - data.Angle) % 360;
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
            }
            while (auxiliarItemsTop.Count() > 0)
            {
                auxiliarItemsTop.RemoveAt(0);
            }

            topPrice = 0;
            for (int i = 0; i < scatterItemsTop.Count(); i++)
            {
                topPrice += scatterItemsTop.ElementAt(i).Price;
            }
            Price_label_up.Text = "Price " + topPrice;
            Clear_up.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_up.TouchDown += clear_event_up;
        }

        void Undo_TouchDown_down(object sender, TouchEventArgs e)
        {
            Clear_down.TouchDown -= undo_event_down;

            for (int i = 0; i < AuxiliarItemsBottom.Count(); i++)
            {
                PhotoData data = auxiliarItemsBottom.ElementAt(i);
                scatterItemsBottom.Add(data);
                ScatterViewItem svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
                svi.Orientation = (360 - data.Angle) % 360;
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
            }
            while (auxiliarItemsBottom.Count() > 0)
            {
                auxiliarItemsBottom.RemoveAt(0);
            }

            bottomPrice = 0;
            for (int i = 0; i < scatterItemsBottom.Count(); i++)
            {
                bottomPrice += scatterItemsBottom.ElementAt(i).Price;
            }
            Price_label_down.Text = "Price " + bottomPrice;
            Clear_down.Source = new BitmapImage(new Uri("Images/clear.png", UriKind.Relative));
            Clear_down.TouchDown += clear_event_down;
        }

        void Clonefront_TouchDown_down(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsTop.Count(); i++ )
            {
                PhotoData photo = ScatterItemsTop.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsBottom.Add(clonedPhoto);
                ScatterViewItem svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (360 - photo.Angle) % 360;
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
                bottomPrice += scatterItemsTop.ElementAt(i).Price;
            }
            Price_label_down.Text = "Price " + bottomPrice;
        }

        void Clonefront_TouchDown_up(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsBottom.Count(); i++)
            {
                PhotoData photo = ScatterItemsBottom.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsTop.Add(clonedPhoto);
                ScatterViewItem svi = scatterTop.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (180 - photo.Angle) % 360;
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
                topPrice += scatterItemsBottom.ElementAt(i).Price;
            }
            Price_label_up.Text = "Price " + topPrice;
        }

        void Clonefront_TouchDown_right(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsLeft.Count(); i++)
            {
                PhotoData photo = ScatterItemsLeft.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsRight.Add(clonedPhoto);
                ScatterViewItem svi = scatterRight.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (270 - photo.Angle) % 360;
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
                rightPrice += scatterItemsLeft.ElementAt(i).Price;
            }
            Price_label_right.Text = "Price " + rightPrice;
        }

        void Clonefront_TouchDown_left(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsRight.Count(); i++)
            {
                PhotoData photo = ScatterItemsRight.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsLeft.Add(clonedPhoto);
                ScatterViewItem svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (90 - photo.Angle) % 360;
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
                leftPrice += scatterItemsRight.ElementAt(i).Price;
            }
            Price_label_left.Text = "Price " +leftPrice;
        }

        
        void Cloneright_TouchDown_up(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsLeft.Count(); i++)
            {
                PhotoData photo = ScatterItemsLeft.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsTop.Add(clonedPhoto);
                ScatterViewItem svi = scatterTop.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (360 - photo.Angle) % 360;
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
                topPrice += scatterItemsLeft.ElementAt(i).Price;
            }
            Price_label_up.Text = "Price " + topPrice;
        }

        void Cloneright_TouchDown_down(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsRight.Count(); i++)
            {
                PhotoData photo = ScatterItemsRight.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsBottom.Add(clonedPhoto);
                ScatterViewItem svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (360 - photo.Angle) % 360;
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
                bottomPrice += scatterItemsRight.ElementAt(i).Price;
            }
            Price_label_down.Text = "Price " + bottomPrice;
        }

        void Cloneright_TouchDown_right(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsTop.Count(); i++)
            {
                PhotoData photo = ScatterItemsTop.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsRight.Add(clonedPhoto);
                ScatterViewItem svi = scatterRight.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (270 - photo.Angle) % 360;
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
                rightPrice += scatterItemsTop.ElementAt(i).Price;
            }
            Price_label_right.Text = "Price " + rightPrice;
        }

        void Cloneright_TouchDown_left(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsBottom.Count(); i++)
            {
                PhotoData photo = ScatterItemsBottom.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsLeft.Add(clonedPhoto);
                ScatterViewItem svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (90 - photo.Angle) % 360;
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
                leftPrice += scatterItemsBottom.ElementAt(i).Price;
            }
            Price_label_left.Text = "Price " + leftPrice;
        }

        void Cloneleft_TouchDown_up(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsRight.Count(); i++)
            {
                PhotoData photo = ScatterItemsRight.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsTop.Add(clonedPhoto);
                ScatterViewItem svi = scatterTop.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (180 - photo.Angle) % 360;
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
                topPrice += scatterItemsRight.ElementAt(i).Price;
            }
            Price_label_up.Text = "Price " + topPrice;
        }

        void Cloneleft_TouchDown_down(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsLeft.Count(); i++)
            {
                PhotoData photo = ScatterItemsLeft.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsBottom.Add(clonedPhoto);
                ScatterViewItem svi = scatterBottom.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (360 - photo.Angle) % 360;
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
                bottomPrice += scatterItemsLeft.ElementAt(i).Price;
            }
            Price_label_down.Text = "Price " + bottomPrice;
        }

        void Cloneleft_TouchDown_right(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsBottom.Count(); i++)
            {
                PhotoData photo = ScatterItemsBottom.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsRight.Add(clonedPhoto);
                ScatterViewItem svi = scatterRight.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (270 - photo.Angle) % 360;
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
                rightPrice += scatterItemsBottom.ElementAt(i).Price;
            }
            Price_label_right.Text = "Price " + rightPrice;
        }

        void Cloneleft_TouchDown_left(object sender, TouchEventArgs e)
        {

            for (int i = 0; i < ScatterItemsTop.Count(); i++)
            {
                PhotoData photo = ScatterItemsTop.ElementAt(i);
                PhotoData clonedPhoto = new PhotoData(photo.Source, photo.Caption, photo.Price, photo.Angle);
                ScatterItemsLeft.Add(clonedPhoto);
                ScatterViewItem svi = scatterLeft.ItemContainerGenerator.ContainerFromItem(clonedPhoto) as ScatterViewItem;
                svi.Orientation = (90-photo.Angle) % 360;
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
                leftPrice += scatterItemsTop.ElementAt(i).Price;
            }
            Price_label_left.Text = "Price " + leftPrice;
        }
    }
}