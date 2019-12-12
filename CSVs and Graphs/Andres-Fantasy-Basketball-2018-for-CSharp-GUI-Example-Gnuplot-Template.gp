reset

BaseName = "BaseNameHere"
######################################### Plotting FG%
#Data = .BaseName.".csv"
Data = BaseName.".csv"
BaseName = BaseName."-FG Percentage vs Week Number"
set datafile separator ","

set terminal pngcairo enhanced size 2560, 1920 background "#FFFFFF" font "Arial Bold,48" linewidth 4
set output BaseName.".png"

set key bottom right

set ylabel "FG Percentage" font ", 60"
set xlabel "Week Number" font ", 60"
#set xrange[:]
#set yrange [:]

plot \
Data using 1:4 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting H2H Points
BaseName = BaseName."-H2H Points vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:2 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting FT%
BaseName = BaseName."-FT Percentage vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "FT Percentage" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:5 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting 3PTM
BaseName = BaseName."-3 PTM vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "3 PTM" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:6 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting PTS
BaseName = BaseName."-Points vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Points" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:7 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting REB
BaseName = BaseName."-Rebounds vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Rebounds" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:8 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting AST
BaseName = BaseName."-Assists vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Assists" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:9 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting STL
BaseName = BaseName."-Steals vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Steals" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:10 with lines 

unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting BLK
BaseName = BaseName."-Blocks vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Blocks" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:11 with lines 


unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"



######################################### Plotting TO
BaseName = BaseName."-Turnovers vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Turnovers" font ", 60"
#set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:12 with lines


unset output
unset xlabel
#unset ylabel
BaseName = "BaseNameHere"


##create .png from .eps
#ConvertString = "i_view64.exe ".BaseName.".eps /convert=".BaseName.".png"
#system ConvertString
