   M S B A M L   `   `   `  ����Q  Mpdumaresq_B42_T02Study, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:pdumaresq_B42_T02Studypdumaresq_B42_T02Study  5   	   '    !pdumaresq_B42_T02Study.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:pdumaresq_B42_T02Study     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $��884.667��6)    � 	Resources 5	      $   pdumaresq_B42_T02Study.dsOwner   dsOwner  hVK_OWNERViewSource �� Source �� Source��%Z   &	        &	      7     5
   
   6   �� 5   
    6;   �� *	HVK_OWNER+8   5      .��5      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ hVK_OWNERDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��10,10,9.667,110.667q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6i   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        oWNER_FIRST_NAMEColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 OWNER FIRST NAME��5   j      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *OWNER_FIRST_NAME+6�     5      -   5        oWNER_LAST_NAMEColumn��$
 OWNER LAST NAME��5   h   $ SizeToHeader 6�    6D   �� *OWNER_LAST_NAME+6�     5      -   5        oWNER_STREETColumn��$
 OWNER STREET��5   b   $ SizeToHeader 6x    6A   �� *OWNER_STREET+6x     5      -   5        oWNER_CITYColumn��$
 
OWNER CITY��5   ^   $ SizeToHeader 6r    6?   �� *
OWNER_CITY+6r     5      -   5        oWNER_PROVINCEColumn��$
 OWNER PROVINCE��5   f   $ SizeToHeader 6~    6C   �� *OWNER_PROVINCE+6~     5      -   5        oWNER_POSTAL_CODEColumn��$
 OWNER POSTAL CODE��5   l   $ SizeToHeader 6�    6F   �� *OWNER_POSTAL_CODE+6�     5      -	   5        oWNER_PHONEColumn��$
 OWNER PHONE��5   `   $ SizeToHeader 6u    6@   �� *OWNER_PHONE+6u     5      -
   5        oWNER_EMAILColumn��$
 OWNER EMAIL��5   `   $ SizeToHeader 6u    6@   �� *OWNER_EMAIL+6u   5      5      5      