   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	   %    WpfApp3.OsszesVevoSzallitoNaplo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Vevő-Szállító Napló��5   	   $	��450��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>   .��5	      � $��0,0,-6,0q�6    � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      ��5   
   �� 5         12 �� Color# �   6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$  vevoszallitonaploOsszesito��5      $
��Left=�67   $	��232��6R   $	��Top=�6_   $	��664��6w      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        sorszam��,  &System.Windows.Controls.DataGridColumn   Header$ Sorszám��5   6     5      -   5        
szamlaszam��$ 
SzamlaSzam��5   9     5      -   5        	nyito��$ Nyitó Érték��5   4     5      -   5        bizszam��$ Bizonylat Szám��5   6     5      -   5        partner��$ PartnerNév��5   6     5      -   5        	munka��$ 
Munka Név��5   4     5      -   5        
megjegyzes��$ Megjegyzés��5   9     5      -	   5        
osszeg��$ Összeg��5   5     5      -
   5        
datumf��$ Dátum��5   5   5!      �� 5"   
   -   5         ��Name$ valaszt��5"      $
��Left=�6$   $��
691,10,0,0q�6?   $	��Top=�6S   $��74��6k   $��Arial Rounded MT Bold)�6v   $��20��6�   ��5#      �� 5$      # �   6"   .@�5&      �� $	��311��6   6+   �� 5'      $
��4541��6   6,   5)      �� 5*   
   -   5        $��Listáz��5*      $
��Left=�6"   $��
691,60,0,0q�6=   $	��Top=�6Q   $��74��6i   $��Arial Rounded MT Bold)�6�   $��26��6�   ��5+      �� 5,      # �   6"   5.      �� 5/   
   -   5        $��	Kilépés��5/      $
��Left=�6#   $��
691,0,0,19q�6>   $��74��6R   $��Arial Rounded MT Bold)�6r   $��Bottom=�6�   $��Center=�6�   $��Center=�6�   ��50      �� 51      # �   6"   53      �� 54   
   -   5        $	��Új��54      $
��Left=�6   $��
10,383,0,0q�69   $��75��6M   $��Arial Rounded MT Bold)�6o   $	��Top=�6�   ��55      �� 56      # �   6"   58      5:      5;      