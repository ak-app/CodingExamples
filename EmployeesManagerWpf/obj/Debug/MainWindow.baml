   M S B A M L   `   `   `  ����H  DEmpManagerWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EmployeeManagerEmployeeManager  5   	       Mitarbeiter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EmployeeManager     5   	     � Title$  Mitarbeiter Manager��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��uiMitarbeiterGrid��5
      $
��Left=�6,   $	��357��6G   $��	10,43,0,0q�6T   $	��Top=�6g   $	��284��6   6�   �� 5   
   $��Mitarbeiter��6   $
��Left=�6&   $��	10,12,0,0q�6A   $	��Top=�6T   �� 5   
   $��Personalnummer:��6   $
��Left=�6*   $��
353,59,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5         ��Name$ uiTextboxId��5      $
��Left=�6'   $��23��6B   $��
463,63,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   $��	Nachname:��6   $
��Left=�6$   $��
353,94,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $��uiTextboxLastname��5      $
��Left=�6+   $��23��6F   $��
463,98,0,0q�6R   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   $��Vorname:��6   $
��Left=�6#   $��353,127,0,0q�6>   $	��Top=�6S   �� 5   
   -   5        $ uiTextboxFirstname��5      $
��Left=�6.   $��23��6I   $��463,131,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��Hinzufügen��5      $
��Left=�6&   $��353,203,0,0q�6A   $	��Top=�6V   $��75��6n   6y   �� 5   
   -   5        $��Löschen��5      $
��Left=�6#   $��433,203,0,0q�6>   $	��Top=�6S   $��75��6k   6v   �� 5   
   -   5        $��	Speichern��5      $
��Left=�6%   $��513,203,0,0q�6@   $	��Top=�6U   $��75��6m   6x   5      5      