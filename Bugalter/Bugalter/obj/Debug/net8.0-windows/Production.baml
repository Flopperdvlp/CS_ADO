   M S B A M L   `   `   `  ����  Bugalter    Bugalter.Production   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Production��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��1��6      AutoGenerateColumns$ False��6D   $��10q�6`   ��6    �� *Productions+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Назва��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
DetailName+  5      $ Кількість��6%    68   �� *QuantityProduced+  5      $ Брак��6%    63   �� *QuantityDefective+  5      $ Ціна��6%    63   �� *DetailPrice+  5      $ Всього��6%    65   �� *	TotalCost+5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5      �� $8��2Загальна вартість виробів: ��6   $
��Bold"�6;   �� 5      $��5,0,0,0q�6N   ��6   �� *TotalProductionValue+ �� StringFormat$ C��6N   5      5      5      