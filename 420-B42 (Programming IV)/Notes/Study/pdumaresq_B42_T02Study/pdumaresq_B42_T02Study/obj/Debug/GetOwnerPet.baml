   M S B A M L   `   `   `  ����Q  Mpdumaresq_B42_T02Study, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:pdumaresq_B42_T02Studypdumaresq_B42_T02Study  5   	   (    "pdumaresq_B42_T02Study.GetOwnerPet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:pdumaresq_B42_T02Study     5   	   -   5          � Title$  GetOwnerPet��5   	   $	��300��6   $��410.953��6*    � 	Resources 5	      '   !pdumaresq_B42_T02Study.dsPetOwner   
dsOwnerPet  hVK_OWNERViewSource �� Source �� Source  hVK_OWNERHVK_PETViewSource��%�   &	        &	      7   &	 B     7    5
   
   6   �� 5   
    6;   �� *	HVK_OWNER+8   �� 5   
    6B   �� *
PET_OWN_FK+8   5      .��5      �  � DataContext# [ 6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ hVK_OWNERDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��10,61,10,131.667q�6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6i   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        oWNER_FIRST_NAMEColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 OWNER FIRST NAME��5   j      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *OWNER_FIRST_NAME+6�     5      -   5        oWNER_LAST_NAMEColumn��$
 OWNER LAST NAME��5   h   $ SizeToHeader 6�    6D   �� *OWNER_LAST_NAME+6�     5      -   5        oWNER_PHONEColumn��$
 OWNER PHONE��5   `   $ SizeToHeader 6u    6@   �� *OWNER_PHONE+6u     5      -   5        !eMERGENCY_CONTACT_PHONEColumn��$
 EMERGENCY CONTACT PHONE��5   x   $ SizeToHeader 6�    6L   �� *EMERGENCY_CONTACT_PHONE+6�   5        5   
   -   5        $ hVK_PETDataGrid��5       .   . $��10,144,287,55.667q�6�   $ VisibleWhenSelected=�6�   ��6g   �� # [ 	 5        5      -   5        pET_NAMEColumn��$
 PET NAME��5   Z   $ SizeToHeader 6l    6=   �� *
PET_NAME+6l   5      �� 5   
   -	   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��	10,10,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -
   5         ��Name$ button��5      $��Search��6!   $
��Left=�62   $��	10,33,0,0q�6M   $	��Top=�6`   $��75��6x   6�   5       5!      