using System;

public class Node
{
    public string foodname;
    public int quantity;
    public float price;
    public int data;
    public Node prev;
    public Node next;
}

public class Program
{
    static Node headc = null, newnode, tailc = null;
    static Node heada = null, taila = null;
    static Node head_s;

    static void AdminMenu()
    {
        Console.WriteLine("\n\t\t\t\t\t\t\t1. View total sales");
        Console.WriteLine("\t\t\t\t\t\t\t2. Add new items in the order menu");
        Console.WriteLine("\t\t\t\t\t\t\t3. Delete items from the order menu");
        Console.WriteLine("\t\t\t\t\t\t\t4. Display order menu");
        Console.WriteLine("\t\t\t\t\t\t\t5. Back To Main Menu \n\n");
        Console.Write("\t\t\t\t\t\t\t   Enter Your Choice --->");
    }

    static void CustomerMenu()
    {
        Console.WriteLine("\n\t\t\t\t\t\t\t1. Place your order");
        Console.WriteLine("\t\t\t\t\t\t\t2. View your ordered items");
        Console.WriteLine("\t\t\t\t\t\t\t3. Delete an item from order");
        Console.WriteLine("\t\t\t\t\t\t\t4. Display final bill");
        Console.WriteLine("\t\t\t\t\t\t\t5. Back To Main Menu \n\n");
        Console.Write("\t\t\t\t\t\t\t   Enter Your Choice --->");
    }

    static Node CreateAdmin(Node head, int data, string foodname, float price)
    {
        newnode = new Node();

        newnode.data = data;
        newnode.price = price;
        newnode.quantity = 0;
        newnode.foodname = foodname;
        newnode.next = null;
        newnode.prev = null;

        Node temp = head;

        if (temp == null)
            heada = taila = newnode;
        else
        {
            while (temp.next != null)
                temp = temp.next;

            temp.next = newnode;
            newnode.prev = taila;
            taila = newnode;
        }

        return heada;
    }

    static Node CreateCustomer(Node head, int data, int quantity)
    {
        newnode = new Node();

        Node temp1 = heada;
        int flag = 0;
        while (temp1 != null)
        {
            if (temp1.data == data)
            {
                flag = 1;
                break;
            }
            temp1 = temp1.next;
        }

        if (flag == 1)
        {
            newnode.data = data;
            newnode.price = quantity * (temp1.price);
            newnode.quantity = quantity;
            newnode.foodname = temp1.foodname;
            newnode.next = null;
            newnode.prev = null;

            Node temp = head;

            if (temp == null)
                headc = tailc = newnode;
            else
            {
                while (temp.next != null)
                    temp = temp.next;

                temp.next = newnode;
                newnode.prev = tailc;
                tailc = newnode;
            }
        }
        else
        {
            Console.WriteLine("\n\t\t\t\t\t\t\tThis item is not present in the menu!\n");
        }
        return headc;
    }

    static void DisplayList(Node head)
    {
        Node temp1 = head;
        if (temp1 == null)
        {
            Console.WriteLine("\n\t\t\t\t\t\t\t\tList is empty!!\n\n");
        }
        else
        {
            Console.WriteLine("\n");
            while (temp1 != null)
            {
                if (temp1.quantity == 0)
                    Console.WriteLine("\t\t\t\t\t\t\t{0}\t{1}\t{2}\n", temp1.data, temp1.foodname, temp1.price);
                else
                {
                    Console.WriteLine("\t\t\t\t\t\t\t{0}\t{1}\t{2}\t{3}\n", temp1.data, temp1.foodname, temp1.quantity, temp1.price);
                }

                temp1 = temp1.next;
            }
            Console.WriteLine("\n");
        }
    }

    static Node TotalSales(int data, int quantity)
    {
        newnode = new Node();
        int flag = 0;

        Node temp1 = heada;
        while (temp1.data != data)
        {
            temp1 = temp1.next;
        }

        newnode.data = data;
        newnode.price = quantity * (temp1.price);
        newnode.quantity = quantity;
        newnode.foodname = temp1.foodname;
        newnode.next = null;
        newnode.prev = null;

        Node temp = head_s;

        if (temp == null)
            head_s = newnode;
        else
        {
            while (temp.next != null)
            {
                if (temp.data == data)
                {
                    flag = 1;
                    break;
                }
                temp = temp.next;
            }

            if (flag == 1)
            {
                temp.quantity += newnode.quantity;
                temp.price += newnode.price;
            }
            else
            {
                temp.next = newnode;
            }
        }

        return head_s;
    }

    static void CalculateTotalSales()
    {
        Node temp = headc;
        while (temp != null)
        {
            head_s = TotalSales(temp.data, temp.quantity);
            temp = temp.next;
        }
    }

    static Node Delete(int data, Node head, Node tail)
    {
        if (head == null)
        {
            Console.WriteLine("\n\t\t\t\t\t\t\tList is empty\n");
        }
        else
        {
            Node temp;
            if (data == head.data)
            {
                temp = head;
                head = head.next;
                if (head != null)
                    head.prev = null;
                temp = null;
            }
            else if (data == tail.data)
            {
                temp = tail;
                tail = tail.prev;
                tail.next = null;
                temp = null;
            }
            else
            {
                temp = head;
                while (data != temp.data)
                {
                    temp = temp.next;
                }
                temp.prev.next = temp.next;
                temp.next.prev = temp.prev;
                temp = null;
            }
        }
        return head;
    }

    static int DeleteAdmin()
    {
        Console.WriteLine("\n\t\t\t\t\tEnter serial no. of the food item which is to be deleted: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Node temp = heada;
        while (temp != null)
        {
            if (temp.data == num)
            {
                heada = Delete(num, heada, taila);
                return 1;
            }
            temp = temp.next;
        }

        return 0;
    }

    static int DeleteCustomer()
    {
        Console.WriteLine("\n\t\t\t\t\tEnter serial no. of the food item which is to be deleted: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Node temp = headc;
        while (temp != null)
        {
            if (temp.data == num)
            {
                headc = Delete(num, headc, tailc);
                return 1;
            }
            temp = temp.next;
        }

        return 0;
    }

    static void DisplayBill()
    {
        DisplayList(headc);
        Node temp = headc;
        float total_price = 0;
        while (temp != null)
        {
            total_price += temp.price;
            temp = temp.next;
        }

        Console.WriteLine("\t\t\t\t\t\t\tTotal price: {0:0.00}\n", total_price);

    }

    static Node DeleteList(Node head)
    {
        if (head == null)
        {
            return null;
        }
        else
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                temp.prev = null;
            }
            temp = null;
            head = null;
        }

        return head;
    }

    static void Admin()
    {
        Console.WriteLine("\n\t\t\t\t\t   ----------------------------------------------\n");
        Console.WriteLine("\t\t\t\t\t\t\t    ADMIN SECTION\n");
        Console.WriteLine("\t\t\t\t\t   ----------------------------------------------\n");
        while (true)
        {
            AdminMenu();

            int opt = Convert.ToInt32(Console.ReadLine());

            if (opt == 5)
                break;

            switch (opt)
            {
                case 1:
                    DisplayList(head_s);
                    break;
                case 2:

                    Console.WriteLine("\n\t\t\t\t\t\t\tEnter serial no. of the food item: ");
                    int num, flag = 0;
                    string name;
                    float price;
                    num = Convert.ToInt32(Console.ReadLine());

                    Node temp = heada;

                    while (temp != null)
                    {
                        if (temp.data == num)
                        {
                            Console.WriteLine("\n\t\t\t\t\t\tFood item with given serial number already exists!!\n\n");
                            flag = 1;
                            break;
                        }
                        temp = temp.next;
                    }

                    if (flag == 1)
                        break;

                    Console.WriteLine("\t\t\t\t\t\t\tEnter food item name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("\t\t\t\t\t\t\tEnter price: ");
                    price = Convert.ToSingle(Console.ReadLine());
                    heada = CreateAdmin(heada, num, name, price);
                    Console.WriteLine("\n\t\t\t\t\t\t\tNew food item added to the list!!\n\n");
                    break;
                case 3:
                    if (DeleteAdmin() == 1)
                    {
                        Console.WriteLine("\n\t\t\t\t\t\t### Updated list of food items menu ###\n");
                        DisplayList(heada);
                    }
                    else
                        Console.WriteLine("\n\t\t\t\t\t\tFood item with given serial number doesn't exist!\n\n");

                    break;
                case 4:
                    Console.WriteLine("\n\t\t\t\t\t\t\t   ### Order menu ###\n");
                    DisplayList(heada);
                    break;

                default:
                    Console.WriteLine("\n\t\t\t\t\t\tWrong Input !! PLease choose valid option\n");
                    break;
            }
        }
    }

    static void Customer()
    {
        int flag = 0;
        string ch;
        Console.WriteLine("\n\t\t\t\t\t   ----------------------------------------------\n");
        Console.WriteLine("\t\t\t\t\t\t\t    CUSTOMER SECTION\n");
        Console.WriteLine("\t\t\t\t\t   ----------------------------------------------\n");
        while (true)
        {
            CustomerMenu();

            int opt = Convert.ToInt32(Console.ReadLine());

            if (opt == 5)
                break;

            switch (opt)
            {
                case 1:
                    DisplayList(heada);
                    Console.WriteLine("\n\t\t\t\t\t\tEnter number corresponding to the item you want to order: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\t\t\t\t\t\tEnter quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    headc = CreateCustomer(headc, n, quantity);
                    break;
                case 2:
                    Console.WriteLine("\n\t\t\t\t\t\t\t  ### List of ordered items ###\n");
                    DisplayList(headc);
                    break;
                case 3:
                    if (DeleteCustomer() == 1)
                    {
                        Console.WriteLine("\n\t\t\t\t\t\t### Updated list of your ordered food items ###\n");
                        DisplayList(headc);
                    }
                    else
                        Console.WriteLine("\n\t\t\t\t\t\tFood item with given serial number doesn't exist!!\n");

                    break;
                case 4:
                    CalculateTotalSales();
                    Console.WriteLine("\n\t\t\t\t\t\t\t ### Final Bill ###\n");
                    DisplayBill();
                    headc = DeleteList(headc);
                    Console.WriteLine("\n\t\t\t\t\t\tPress any key to return to main menu:\n\t\t\t\t\t\t");
                    Console.In.ReadLine();
                    flag = 1;
                    break;
                default:
                    Console.WriteLine("\n\t\t\t\t\t\tWrong Input !! PLease choose valid option\n");
                    break;
            }
            if (flag == 1)
                break;
        }
    }

    static void MainMenu()
    {
        Console.WriteLine("\n                                 **************************************************************************\n");
        Console.WriteLine("                                                     WELCOME TO RESTAURANT MANAGEMENT SYSTEM\n");
        Console.WriteLine("                                 **************************************************************************\n\n\n");
        Console.WriteLine("\t\t\t\t\t\t\t1. ADMIN SECTION--> \n");
        Console.WriteLine("\t\t\t\t\t\t\t2. CUSTOMER SECTION--> \n");
        Console.WriteLine("\t\t\t\t\t\t\t3. Exit--> \n\n");
        Console.Write("\t\t\t\t\t\t\tEnter Your Choice --->");
    }

    public static void Main(string[] args)
    {
        heada = CreateAdmin(heada, 1, "Hot and Sour Soup", 100);
        heada = CreateAdmin(heada, 2, "Manchow Soup", 200);
        heada = CreateAdmin(heada, 3, "Manchurian Noodles", 150);
        heada = CreateAdmin(heada, 4, "Fried Rice", 180);
        heada = CreateAdmin(heada, 5, "Hakka Noodles ", 80);

        while (true)
        {
            MainMenu();
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 3)
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t**********Thank you!!**********\n");
                break;
            }

            switch (choice)
            {
                case 1:
                    Admin();
                    break;
                case 2:
                    Customer();
                    break;
                case 3:
                    break;

                default:
                    Console.WriteLine("\n\t\t\t\t\t\tWrong Input !! PLease choose valid option\n");
                    break;
            }
        }
    }
}


