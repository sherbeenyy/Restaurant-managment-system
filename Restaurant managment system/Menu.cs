using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Menu
    {
    // variables

    private string _food_name;
    private string _food_description;
    private decimal _food_price;
    private string _food_category;


    // constructor 
    public Menu(string food_name, string food_description, decimal food_price, string food_category)
    {
        _food_name = food_name;
        _food_description = food_description;
        _food_price = food_price;
        _food_category = food_category;
    }
    public Menu()
    {


    }



    // get and sets for the new menu 

    public string FoodName 

    { get 
        { return _food_name; } 
        set 
        { _food_name = value; } 
    }

    public string FoodDescription
    {
        get
        { return _food_description; }
        set
        {
            _food_description = value;     
        }
    }

    public decimal FoodPrice
    {
        get 
        { 
            return _food_price; 
        }
        set
        
        {
            _food_price = value; 
        }
    }

    public string FoodCategory
    {
        get 
        { 
            return _food_category; 
        }
        set
        { _food_category = value; }
    }

}

