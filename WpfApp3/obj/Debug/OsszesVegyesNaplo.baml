   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.OsszesVegyesNaplo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  VegyesNaplo��5   	   $	��450��6   $	��800��6*    � 
ResizeMode$ NoResize=�66   .��5	      � $��	0,0,-6,-3q�6   ��5
   
   �� 5         12 �� Color# �   6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ VegyesListaz��5      $
��Left=�6)   $	��380��6D   $��Bottom=�6Q   $	��618��6l   $��	10,0,0,39q�6x      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	sorsz��,  &System.Windows.Controls.DataGridColumn   Header$ Sorszám��5   4     5      -   5        	datum��$ Dátum��5   4     5      -   5        megj��$ Megjegyzés��5   3     5      -   5        	bizsz��$ BizonylatSzam��5   4     5      -   5        	munka��$ MunkaKod��5   4     5      -   5        partner��$ 
PartnerKod��5   6     5      -   5        
osszeg��$ Könyvelt Összeg��5   5   5      �� 5   
   -	   5        $��	Kilépés��5      $
��Left=�6#   $��695,378,0,0q�6>   $	��Top=�6S   $��75��6k   $��Arial Rounded MT Bold)�6�   ��5      �� 5       # �   6"   5"      �� 5#   
   -
   5        $��Listáz��5#      $��695,127,0,0q�6"   $	��Top=�67   $��Arial Rounded MT Bold)�6d   $
��Left=�6�   $��75��6�   ��5$      �� 5%      # �   6"   5'      (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$	 tol��5(      $
��Left=�6"   $��
660,50,0,0q�6=   $	��Top=�6Q   �� 5)   
   $��Időszak��6   $
��Left=�6"   $��
660,19,0,0q�6=   $	��Top=�6Q     5*   
   -   5        $ ig��5*      $
��Left=�6!   $��
662,82,0,0q�6<   $	��Top=�6P    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5+      V� 5,      .~�5-      �� �� 5.       �� AngleX$ 3.302Q�6$   �� 5/      T� 50      	 T� X$	 -0.692Q�6)   51      53      �� 54   
   -   5        $	��Új��54      $
��Left=�6   $��695,236,0,0q�69   $	��Top=�6N   $��75��6f   $��Arial Rounded MT Bold)�6�   $��Center=�6�   $��Center=�6�   ��55      �� 56      # �   6"   58      5:      5;      