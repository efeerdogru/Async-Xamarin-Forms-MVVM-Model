using AsyncTest.Models;

namespace AsyncTest
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            ((BaseModel) BindingContext).Initialize(this);
        }
    }
}