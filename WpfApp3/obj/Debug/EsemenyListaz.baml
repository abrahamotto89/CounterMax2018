   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.EsemenyListaz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  Események Listázása��5   	   $	��390��6%   $	��713��62    � 
ResizeMode$ NoResize=�6>   .��5	      � ���	#FFCFDEF8$��0,0,2,-1q�6"    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ Lista4��5      $
��Left=�6I   $��0,0,0,95q�6d   $	��564��6v   ��6#   �� *esemenyLista+��5      �� 5       �� View 5      �� 5      P�5      �� 5      $��Esemény ideje��6[    �� Width$	 100��6r    �� DisplayMemberBinding 6*   �� *esemenyIdopont+6�   �� 5      $��Esemény Tárgya��6]   $	 100��6u    6*   �� *esemenyMegnevezes+6�   �� 5      $��	Helyszín��6\   $	 100��6n    6*   �� *esemenyHelyszin+6|   �� 5      $��Kontakt Tel��6[   $	 100��6p    6*   �� *esemenyKontakt+6~   �� 5      $��Időzítés��6`   $	 100��6r    6*   �� *esemenyIsIdozitoIdo+6�   5!      5#      �� 5$   
   -   5         ��Name$	 mod��5$      $��	Módosít��6   $
��Left=�60   $��
609,10,0,0q�6K   $	��Top=�6_   $��75��6w   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   $��22��6�   �� 5%   
   -   5        $
 torl��5%      $��Törlés��6   $
��Left=�60   $��
609,64,0,0q�6K   $	��Top=�6_   $��75��6w   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   $��20��6�   �� 5&   
   -   5        $��	Kilépés��5&      $
��Left=�6#   $��609,331,0,0q�6>   $	��Top=�6S   $��75��6k   ���	#FFCFDEF8$��Arial Rounded MT Bold)�6�   $��22��6�    J� RenderTransformOrigin$ 
-0.113,0.6&�6�   5(      5)      