   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.FokonyvMegjelenit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Főkönyvi Kivonat��5   	   $	��450��6"   $	��800��6/    � 
ResizeMode$ NoResize=�6;   .��5	      � $��	0,0,-8,-3q�6   ��5
   
   �� 5         12 �� Color# �   6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ fokonyvLista��5      $
��Left=�6)   $	��420��6D   $	��Top=�6Q   $	��689��6i   ��5      �� 5      # �   6"      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        fokonyvszam��,  &System.Windows.Controls.DataGridColumn   Header$ Főkönyvi Szám��5   :      
Foreground �	#FF3C1616   FontSize$ 14Q�6i      
FontFamily$ Arial Black)�6w     5      -   5        
megnev��$ Megnevezés��5   5    �	#FFAC3867$ 14Q�6`   $ Arial Black)�6n     5      -   5        	forgT��$ 
T Forgalom��5   4    �	#FFAC3867$ 14Q�6_   $ Arial Black)�6m     5      -   5        	forgK��$ 
K Forgalom��5   4    �	#FFAC3867$ 14Q�6_   $ Arial Black)�6m     5      -   5        egyenleg��$ Egyenleg��5   7    �	#FFAC3867$ 14Q�6`   $ Arial Black)�6n   5      �� 5   
   -   5        $��	Kilépés��5      $
��Left=�6#   $��707,388,0,0q�6>   $	��Top=�6S   $��75��6k   $��Arial Rounded MT Bold)�6�   ��5      �� 5      # �   6"   5       �� 5!   
   -   5        	 ��Name$	 	nyomtatas��5!      $��
Nyomtatás��6$   $
��Left=�68   $��
707,10,0,0q�6S   $	��Top=�6g   $��75��6   $��Arial Rounded MT Bold)�6�   ��5"      �� 5#      $ 	#FFCFDEF8��6"   5%      5'      5(      