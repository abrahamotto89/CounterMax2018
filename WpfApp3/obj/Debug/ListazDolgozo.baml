   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.ListazDolgozo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$   Dolgozók Nyilvántartása��5   	   $	��450��6)   $	��800��66    � 
ResizeMode$ NoResize=�6B    � 	Resources 5	         piroska 
 Color1��%V   &	        &	 !     ��5
   
   	#FF811E1E��6+   ��5   
   	#FF832A2A��6*   5      .��5      � $��
0,0,-6,-18q�6   ��5   
   �� 5        12 �� Color# �  6    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $
��196* �6   �� 5      $
��570* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dolgozoLista��5      $��Right=�6)   $	��794��6E   $��	0,0,6,109q�6�   $��3��6�    J� OpacityMask 5      �� 5      # �  6"   ��5      �� 5      # �  6"   ��5      �� 5      # �  6"      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      -   5        	azonosito��,  &System.Windows.Controls.DataGridColumn   Header$ Azonosító��5!   8     5"      -   5        nev��$
 Név��5"   2     5#      -   5        szulIdo��$ Születési idő��5#   6     5$      -   5        szulHely��$ 
Szül.Hely��5$   7     5&      -   5        anyjaNev��$ 
Anyja neve��5&   7     5'      -   5        cim��$
 Cím��5'   2     5(      -   5        	adosz��$ 
Adószáma��5(   4     5)      -	   5        	tajsz��$ Tajszám��5)   4     5,      -
   5        felvido��$ Felvétel ideje��5,   6     5-      -   5        
jogviszony��$ Jogviszonya��5-   9     5.      -   5        haviber��$ 
Havi Bére��5.   6     5/      -   5        
szamfejtes��$ SzámFejtés Volt?��5/   9   56      �� 57   
   -   5        $��	Kilépés��57      $��462,384,0,0q�6#   	 J� RenderTransformOrigin$	 
0.547,-0.9&�68   $��2��6p   $��Arial Rounded MT Bold)�6�   $��25��6�   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $	��Top=�6  $��85��6(  ��58      �� 59      $ 	#FFCFDEF8��6"   5;      �� 5<   
   -   5        $��Új dolgozó��5<      $
��Left=�6&   $	��Top=�6A   $��77��6Y   $��
10,384,0,0q�6d   $��25��6x   $��Arial Rounded MT Bold)�6�   $	 0.5,0.5&�6�   $��1��6�   ��5=      �� 5>      $ 	#FFCFDEF8��6"   5@      �� 5A   
   -   5        
 ��Name$

 torl��5A      $��Törlés��6   $
��Left=�60   $��116,384,0,0q�6K   $	��Top=�6`   $��75��6x   $	 -0.173,0.545&�6�   $��25��6�   $��Arial Rounded MT Bold)�6�   $��1��6�   ��5B      �� 5C      $ 	#FFCFDEF8��6"   5E      �� 5F   
   -   5        $	
 mod��5F      $��Módosítás��6   $
��Left=�62   $��
23,384,0,0q�6M   $	��Top=�6a   $��75��6y   $��25��6�   $��2��6�   $��Arial Rounded MT Bold)�6�   $	 0.5,0.5&�6�   ��5G      �� 5H      $ 	#FFCFDEF8��6"   5J      �� 5K   
   -   5        $
 konyvel��5K      $��BérFeladás��6"   $��2��67   $
��Left=�6G   $��134,384,0,0q�6b   $	��Top=�6w   $	��137��6�   $��25��6�   $��Arial Rounded MT Bold)�6�   $	 0.5,0.5&�6�   ��5L      �� 5M      $ 	#FFCFDEF8��6"   5O      5Q      5R      