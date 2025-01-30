namespace Problems;

     public class ListNode { public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
     }

    public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return l1;
    }
    
    public int ConvertListToNumber(ListNode head)
    {
        int number = 0;
        int units = 1;
        var list = head;
        while (list.next != null)
        {
            number += list.val * units;
            units *= 10;
            list = list.next;
        }

        return number;
    }

    public ListNode SplitNumberInList(int number)
    {
        ListNode node = new ListNode();
        node.val = number % 10;
        number /= 10;
        node.next = null;
        while (number != 0)
        {
            node.next = new ListNode(number % 10, null);
            node = node.next;
            number /= 10;
        }

        return node;
    }
}