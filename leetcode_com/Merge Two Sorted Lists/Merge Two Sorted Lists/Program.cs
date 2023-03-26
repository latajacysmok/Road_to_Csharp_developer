/*You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
 */

using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;

List<int> list1 = new List<int>() { 1, 2, 4 };
List<int> list2 = new List<int>() { 1, 3, 4 };
list1.AddRange(list2);
list1.Sort();
foreach (int num in list1.Distinct()) Console.WriteLine(num);


