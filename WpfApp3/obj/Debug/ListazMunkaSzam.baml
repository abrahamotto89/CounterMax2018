   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.ListazMunkaSzam   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Munkaszám felvétel��5   	   $	��300��6$   $	��300��61    � 
ResizeMode$ NoResize=�6=   .��5	      � ���	#FFCFDEF8.+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ munkaSzamTetelek��5
      $
��Left=�6-   $	��232��6H   $	��Top=�6U   $	��294��6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        munkasz��,  &System.Windows.Controls.DataGridColumn   Header$ 
Munkaszám��5   6     5      -   5        
megnevezes��$ Munka megnevezés��5   9   5      �� 5   
   -   5        $��Kiválasztás��5      $
��Left=�6'   $��
10,237,0,0q�6B   $	��Top=�6V   $��84��6n   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5   
   -   5        $	��Új��5      $
��Left=�6   $��116,237,0,0q�69   $	��Top=�6N   $��75��6f   $��Arial Rounded MT Bold)�6�   $��20��6�   ��5      �� 5         12 �� Color# �   6"   5      �� 5   
   -   5        $��Törlés��5      $
��Left=�6"   $��209,237,0,0q�6=   $	��Top=�6R   $��75��6j   $��Arial Rounded MT Bold)�6u   ��5      �� 5      # �   6"   5      5       5!      