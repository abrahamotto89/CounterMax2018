   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.FelveszMunkaSzam   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Munkaszám felvétele��5   	   $	��300��6%   $	��450��62    � 
ResizeMode$ NoResize=�6>   .��5	      � ���	#FFCFDEF8 � ColumnDefinitions 5
   
   �� 5      $	��69* �6   �� 5      $
��152* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ munkaSzamTetelek��5      $
��Left=�6-   $	��149��6H   $	��Top=�6U   $	��442��6m   $��2��6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        munkasz��,  &System.Windows.Controls.DataGridColumn   Header$ 
Munkaszám��5   6     5      -   5        	munkamegn��$ Munka Megnevezés��5   8   5      �� 5   
   -   5         ��Name$ uj��5      $	��Új��6   $
��Left=�6*   $��
10,238,0,0q�6E   $	��Top=�6Y   $��53��6q   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5   
   -   5        $	 mod��5      $��Módosítás��6   $
��Left=�62   $��
68,238,0,0q�6M   $	��Top=�6a   $��69��6y   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5   
   -   5        $
 torl��5      $��Törlés��6    $
��Left=�61   $��	4,238,0,0q�6L   $	��Top=�6_   $��56��6w   $��1��6�   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   6�   �� 5   
   -   5        $
 ment��5      $��Mentés��6   $
��Left=�60   $��
65,238,0,0q�6K   $	��Top=�6_   $��60��6w   $��1��6�   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5   
   -   5        $ kilep��5      $��	Kilépés��6    $
��Left=�62   $��219,238,0,0q�6M   $	��Top=�6b   $��75��6z   $��1��6�   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5   
   $��
Munkaszám��6   $
��Left=�6$   $��	0,154,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ -0.895,0.385&�6j   �� 5   
   $��Megnevezés��6   $
��Left=�6%   $��	0,185,0,0q�6@   $	��Top=�6S   �� 5    
   -	   5         ��Name$ 	munkaszam��5       $
��Left=�6%   $��23��6@   $��
81,157,0,0q�6L   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��120��6�   $��2��6�   �� 5!   
   -
   5        $ munkaNev��5!      $
��Left=�6$   $��23��6?   $��
81,185,0,0q�6K   $
	 Wrap=�6_   $	��Top=�6s   $	��120��6�   $��2��6�   5#      5$      