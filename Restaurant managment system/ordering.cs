using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class Ordering 
{
    // variables

    private int _orderID;
    private int _orderitmes;
    private int _receipt;
    private int _tax;
    private int _serviceCharge;
    private string _orderDate;


    // constructor

    public Ordering(int orderID, int orderitmes, int receipt, int tax, int serviceCharge, string orderDate)
    {
        _orderID = orderID;
        _orderitmes = orderitmes;
        _receipt = receipt;
        _tax = tax;
        _serviceCharge = serviceCharge;
        _orderDate = orderDate;
    }

    // default constructor

    public Ordering()
    {
    }

    


}


