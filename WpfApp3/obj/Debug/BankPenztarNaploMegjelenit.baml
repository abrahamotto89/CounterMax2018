   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	   (    "WpfApp3.BankPenztarNaploMegjelenit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Pénzár/Bank Napló��5   	   $	��450��6#   $	��800��60    � 
ResizeMode$ NoResize=�6<    � 	Resources 5	         kék��%+   &	        ��5
   
   	#FF00A2FF��6'   5      ��5      �� 5   
    �� Color# �   6   .��5      � ���	#FFCFDEF8.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ BankNaploOsszesito��5      $
��Left=�6/   $	��373��6J   $	��Top=�6W   $	��595��6o   ��5      �� 5      # � ��6"      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        sorszam��,  &System.Windows.Controls.DataGridColumn   Header$ Sorszám��5   6     5      -   5        
szamlaszam��$ 
SzamlaSzam��5   9     5      -   5        	nyito��$ Nyitó Érték��5   4     5      -   5        bizszam��$ Bizonylat Szám��5   6     5      -   5        partner��$ PartnerNév��5   6     5      -   5        	munka��$ 
Munka Név��5   4     5      -   5        
megjegyzes��$ Megjegyzés��5   9     5      -	   5        
osszeg��$ Összeg��5   5     5      -
   5        
datumf��$ Dátum��5   5   5       �� 5!   
   -   5         ��Name$ valaszt��5!      $
��Left=�6$   $��
651,39,0,0q�6?   $	��Top=�6S   $	��120��6k   $��Arial Rounded MT Bold)�6w   ���	#FFCFDEF8.@�5"      �� $	��384��6   6+   �� 5#      $
��3811��6   6,   �� 5$      $
��3821��6   6,   5'      �� 5(   
   $��KÉREM VÁLASSSZON ��6   $
��Left=�6,   $��	645,0,0,0q�6G   $	��Top=�6Z   $��Arial Rounded MT Bold)�6r   ���	#FFCFDEF86�   �� 5)   
   -   5        $��	Lekérdez��5)      $
��Left=�6$   $	��Top=�6?   $��77��6W   $��
705,97,0,0q�6b   $��24��6v   $��Arial Rounded MT Bold)�6�   ���	#FFCFDEF86�   �� 5*   
   -   5        $��	Kilépés��5*      $
��Left=�6#   $	��Top=�6>   $��77��6V   $��705,386,0,0q�6a   $��24��6v   $��Arial Rounded MT Bold)�6�   ���	#FFCFDEF86�   5+      5,      