using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Etlap
{
    /// <summary>
    /// Interaction logic for FoodForm.xaml
    /// </summary>
    public partial class FoodForm : Window
    {
		FoodService foodService;
        public FoodForm(FoodService foodServ)
        {
            InitializeComponent();
			this.foodService = foodServ;
			init();
		}

		private void init() 
		{
			List<String> list = foodService.Courses();
			foreach (string i in list)
			{
				BoxCourse.Items.Add(i);
			}
		}

		private void butnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Food food = MakeFood();
				if (foodService.Create(food))
				{
					MessageBox.Show("Sikeres hozzáadás");
					boxName.Text = "";
					boxDesc.Text = "";
					boxPrice.Text = "";
					BoxCourse.Text = "";
				}
				else
				{
					MessageBox.Show("Hiba történt a hozzáadás során");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private Food MakeFood()
		{
			string name = boxName.Text.Trim();
			string desc = boxDesc.Text.Trim();
			string priceText = boxPrice.Text.Trim();
			string course = BoxCourse.Text.Trim();

			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Name Required");
			}
			if (string.IsNullOrEmpty(priceText))
			{
				throw new Exception("Price Required");
			}
			if (!int.TryParse(priceText, out int price))
			{
				throw new Exception("Price must be a number");
			}
			if (string.IsNullOrEmpty(course))
			{
				throw new Exception("Course required");
			}

			Food food = new Food();
			food.Name = name;
			food.Desc = desc;
			food.Price = price;
			food.Course = course;
			return food;
		}
	}
}
