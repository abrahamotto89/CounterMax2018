   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.PartnerListaz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  	Partnerek��5   	   $	��450��6   $	��800��6(    � 
ResizeMode$ NoResize=�64   .��5	      � $��0,0,2,-3q�6    � ColumnDefinitions 5
   
   �� 5      ��5   
   �� 5         12 �� Color# �   6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ partnerLista��5      $
��Left=�6*   $	��365��6E   $	��Top=�6R   $	��622��6j      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	partnerId��,  &System.Windows.Controls.DataGridColumn   Header$ 	PartnerId��5   8     5      -   5        
partnerNev��$
 Név��5   9     5      -   5        
partnerAdo��$ 	Adószám��5   9     5      -   5        
partnerCim��$
 Cím��5   9     5      -   5        partnerCegj��$ Cégjegyzék Szám��5   :     5      -   5        partnerBank��$
 Bank��5   :     5       -   5        partnerBanksz��$ Bankszámla szám��5    <     5!      -	   5        
partnerTel��$ Telefon��5!   9     5"      -
   5        partnerMail��$ 
Email cím��5"   :     5#      -   5        partnerIban��$ Iban azonosító��5#   :   5)      �� 5*   
   -   5        $��	Kilépés��5*      $
��Left=�6#   $��547,379,0,0q�6>   $��75��6S   $��Arial Rounded MT Bold)�6s   $��Center=�6�   $��Center=�6�   $	��Top=�6�   $��25��6�   ��5+      �� 5,      # �   6"   5.      �� 5/   
   -   5        $	��Új��5/      $
��Left=�6   $��
10,379,0,0q�69   $��75��6M   $��Arial Rounded MT Bold)�6o   $	��Top=�6�   $��25��6�   ��50      �� 51      # �   6"    J� OpacityMask 53      �� 54      # �   6"   56      �� 57   
   -   5         ��Name$	 mod��57      $��Módosítás��6   $
��Left=�62   $��129,379,0,0q�6M   $	��Top=�6b   $��75��6z   $��Arial Rounded MT Bold)�6�   $��25��6�   ��58      �� 59      # �   6"   5;      �� 5<   
   -   5        $
 torl��5<      $��Törlés��6   $
��Left=�60   $��246,379,0,0q�6K   $	��Top=�6`   $��75��6x   $��Arial Rounded MT Bold)�6�   $��25��6�   ��5=      �� 5>      # �   6"   5@      5A      5B      