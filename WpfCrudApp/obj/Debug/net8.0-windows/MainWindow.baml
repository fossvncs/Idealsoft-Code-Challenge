   M S B A M L   `   `   `  ����E  AWpfCrudApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfCrudApp
WpfCrudApp  5   	       WpfCrudApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfCrudApp     5   	     � Title$  Idealsoft Code Challenge��5   	   $	��450��6*   $	��800��67    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Right=�6"   $��10q�6>   .+�5      �� -   5        $��Create User��5      $
��10,5q�5       � Cursor$
 Hand��5      
���/���
���   �$��Segoe UI)�5      5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns$ False��5   1      
IsReadOnly$
 True��5      $��10q�6%   $��Stretch=�5      $��Stretch=�61   $��16(�5      ��5      �� *Users+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
FontFamily$ Segoe UI)�61   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6^   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6G   �� *Id+6^     5#      $
 Name��6%   $ Segoe UI)�63   $	 * 6b   
 6I   �� *Name+6b     5$      $ Surname��6%   $ Segoe UI)�66   $	 * 6h   
 6L   �� *	Surname+6h     5%      $ Phone��6%   $ Segoe UI)�64   $	 * 6d   
 6J   �� *Phone+6d   4  .System.Windows.Controls.DataGridTemplateColumn  5'      $ Actions��6)   $
	 0.5* 6:      CellTemplate 5(      �� 5)      .R�5*      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5+   "   �� -   5        $��✏️��5+   )   $��5,0,5,0q�5,   )   $
 Hand��5.   )   
����  �
�������$��Segoe UI)�51   )   ��5-   )   �� 51   )   �� 52   "   -   5        $��🗑️��52   )   $��5,0,5,0q�54   )   
���  ��
�������$
 Hand��57   )   $��Segoe UI)�5:   )   ��58   )   �� 5:   )   5;      5<      5>      5@      5A      5B      