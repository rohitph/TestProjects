   M S B A M L   `   `   `  ����J  FSearchResultsUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SearchResultsUI.ViewSearchResultsUI.View  5      +    %SearchResultsUI.View.GoogleSearchView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:SearchResultsUI.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��200��6   �� 5      .+�5   
   �� $��10q�6   
�������$��40(�63   $��5��6A   �� 5      
���  ��.�6(   Google Search67   	Storage5      �� 5   
   $	��URL��6   $��1��6   $��5q�6+   �� 5   
   $��1��6L   $��1��6Y   ��6   �� *Url+ �� UpdateSourceTrigger$ PropertyChanged=�6Y   �� 5    
   $��Max Results��6   $��2��6&   $��5q�63   �� 5!   
   $��2��6S   $��1��6`   ��6   �� *
MaxResults+$ PropertyChanged=�6`   �� 5#   
   $��Search Keywords��6   $��3��6*   $��5q�67   �� 5$   
   $��3��6W   $��1��6d   ��6   �� *SearchKeywords+$ PropertyChanged=�6d   �� 5&   
   $��Term To Appear in Results��6   $��4��64   $��5q�6A   �� 5'   
   $��4��6U   $��1��6b   ��6   �� *TermToAppear+$ PropertyChanged=�6b   �� 5)   
   $��5��6   $��4��6"    �� Orientation$ 
Horizontal=�66   $
��Left=�6O   $��Bottom=�6j   .+�5*      �� $��Get Results��6   $��5q�6J   ��6+   �� *
GetCommand+6J   5+      �� 5.   
   $��Search Result Positions��6   $��6��62   $��5q�6?   �� 50   
   $��6��6P   $��1��6]   ��6   �� *	Results+$ PropertyChanged=�6]   52      53      