   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.FoAblak   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Counter Max 2018 v1.0��5   	   $	��500��6'   $	��800��64    � Icon$ Properties/könyvelő.jpg��6@    � UseLayoutRounding .   � WindowStartupLocation$ Manual=�6y    � SizeToContent$ WidthAndHeight=�6�    � 
ResizeMode$ NoResize=�6�   ��5	      �� 5
   
    �� ImageSource$ Properties/könyvelő.jpg��6   .��5      � $��-10,-27,0,-1q�6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.016Q�6"   T� 5      5      	 � ColumnDefinitions	 5   
   �� 5      .+�5   
   o� $��
7,25,0,413q�6   $
��Left=�6#    .  $
��Bold"�6n   $	��623��6�   ��6X   Z� .@�5      m� $��Adatok��6   $��18(�6'   ���	#FFCFDEF8.@�5      m� -   5        $��Ügyfél választás��5      6Q   m� 5      -   5        $��	Kilépés��5      6H   5      m� 5      $��Partner Kezelő��6   ���	#FFCFDEF8$��18(�6F   .@�5      m� -   5        $��Partner Lista��5      6N   m� 5       -   5        $��Partner Hozzáadás��5       6Q   m� 5!      -   5        $��Adatok módosítása��5!      6Q   5"      m� 5#      $��Könyvelés��6   ���	#FFCFDEF8$��18(�6A   .@�5$      m� -   5        $��Nyitó Napló��5$      6I   m� 5%      -   5        $��Záró Napló��5%      6K   m� 5&      -   5        $��Vevő-Szállító Napló��5&      6S   m� 5'      -	   5        $��Pénztár Napló��5'      6P   m� 5(      -
   5        $��Bank Napló��5(      6K   m� 5)      -   5        $��Vegyes Napló��5)      6M   5*      m� 5+      -   5        $��Naptár��5+      ���	#FFCFDEF8$��18(�6>   .@�5,      m� -   5        $��Esemény felvétele��5,      6Q   m� 5-      -   5        $��Események Listázása��5-      6S   5.      m� 5/      $��Kimutatások��6   $	��119��6,   ���	#FFCFDEF8$
��Bold"�6O   $��18(�6a   .@�51      m� -   5        $��Bank/Pénztár��51      6M   m� 52      -   5        $��Vegyes��52      6G   m� 53      -   5        $��Vevő/Szállító��53      6N   m� 54      -   5        $��Mérleg��54      6G   m� 55      -   5        $��Főkönyvi Kivonat��55      6Q   56      m� 57      $��	Dolgozók��6   $	��103��6)   ���	#FFCFDEF8$
��Bold"�6L   $��18(�6^   .@�58      m� -   5        $��	Felvétel��58      6I   m� 59      -   5        $��Nyilvántartás��59      6O   m� 5:      -   5        $��BérSzámFejtés��5:      6O   m� 5;      -   5        $��Bérfeladás��5;      6K   m� 5<      -   5        $��Bérfizetés��5<      6K   5=      5>      �� 5?   
   -   5        
 ��Name$
 bejelent��5?      $�� ��6"   $��649,0,9,446q�6-   $��29��6B   $��Arial Rounded MT Bold)�6N   $��14(�6q   ���	#FFCFDEF8$��Bottom=�6�   $��Italic$�6�   $
��Bold"�6�   �� 5@   
   -   5         ��Name$ penztar��5@      $
��Left=�6#   $��28��6>   $��113,119,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��110��6�   $ 0.281,0.538&�6�   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   $��14(�6  .��6%  z�5A      V� 5B      .~�5C      �� �� 5D       �� AngleX$ 1.905Q�6$   �� 5E      T� 5F       T� X$ 0.501Q�6)   5G      .��5H   '   5I      �� 5J   
   $��
Pénztár:��6   $��
18,120,0,0q�6#   $	��Top=�67   ���	#FFCFDEF8$��16(�6f   $��28��6t   $��Arial Black)�6�   $
��Left=�6�   �� 5K   
   $��Bank:��6   $
��Left=�6    $��
19,161,0,0q�6;   $	��Top=�6O   $��81��6g   ���	#FFCFDEF8$��16(�6�   $��28��6�   $��Arial Black)�6�   �� 5L   
   -   5        $
 bank��5L      $
��Left=�6    $��28��6;   $��113,161,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��110��6�   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   $��14(�6�   �� 5M   
   -   5        $
 vallalkozas��5M      $�� ��6%   $��
12,0,581,0q�60   $��14(�6D   $
��Bold"�6R   $��Arial Rounded MT Bold)�6d   $��30��6�   $��Stretch=�6�   ���	#FFCFDEF8$��Bottom=�6�   �� 5O   
   $��Közelgő Események��6   $��578,67,42,0q�6,   $	��Top=�6A   $��16(�6Y   $
��Bold"�6g   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   �� 5P   
   -   5        $��Kijelentkezés��5P      $
��Left=�6)   $��670,458,0,0q�6D   $	��Top=�6Y   $	��125��6q   $��Arial Rounded MT Bold)�6}   $��30��6�   $��16(�6�   ���	#FFCFDEF86�   �� 5Q   
   $
��Left=�6   $	��100��6,   $	��Top=�69   $	��100��6Q   �� 5R   
   $��71��6   $��
10,428,1,1q�6   $	��793��61   $��Center=�6=   &   System.Windows.Controls.DataGrid  5S   
   -   5          Name$ esemenyFoablakLista��5S      $	��148��60   $��529,101,10,251q�6=   $	��265��6U      Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      -   5        eido��,  &System.Windows.Controls.DataGridColumn   Header$ Esemény ideje��5U   3      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6J     5V      -    5        emegnev��$ Esemény tárgya��5V   6     5W      -!   5        	ehelyszin��$ 	Helyszín��5W   8   $	 100 6J     5X      -"   5        ekontakt��$ Kontakt Tel��5X   7   $	 100 6L   5\      5^      5_      