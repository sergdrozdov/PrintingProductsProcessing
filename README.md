In regards to the simple coding task attached to this email you will find a fixed length txt file.
This is a sample of an ASN (Acknowledgement Shipping Notification) message that we receive from one of our suppliers.
Each HDR section, represents a carton box, and the lines below the HDR describe the contents of the box.
When we reach another HDR section, it means that there is another box and we repeat the process from the beginning.

Data file structure:
---------------------------------------------
HDR  BKPT777                                                                         6874453I                           
LINE G000009760                           9781473663800                     12     
LINE G000009760                           9781473667273                     2      
LINE G000009760                           9781473665798                     1      

Description:
---------------------------------------------
HDR             - just a keyword telling that a new box is being described.
BKPT777         - Supplier identifier.
6874453I        - Carton box identifier. Displayed on the box.
LINE            - keyword to identify product item in the box.
G000009760      - Our PO Number that we sent to the supplier.
9781473663800   - ISBN 13 (product barcode).
12              - Product quantity.


A few important notes: the file could be very large and exceed the available RAM. So try to optimize memory usage while reading it.

The function should return an enumerable array of objects (see below).

IMPORTANT: The task you are going to resolve is used to estimate your approach and solution. It is a part of a read business task.

    The code class is given as example it can be modified by you if need to achieve a goal.
    Think about the cases that can be while working with files (not exists, scheme file is broken)
    Do not try to right code in 5 minutes, first think and plan, then implement.
    You can find some help how to work with big files in internet but not just copy, think first.
    If you have any question about task please feel free to ask, if you do not understand something again please feel free to ask.

public class Carton
{
    public string SupplierIdentifier { get; set; }
    public string Identifier { get; set; }

    public IReadOnlyCollection<Content> Contents { get; set; } 

    public class Content
    {
        public string PoNumber { get; set; }
        public string Isbn { get; set; }
        public int Quantity { get; set; }

    }
}

Look forward to seeing your solution.