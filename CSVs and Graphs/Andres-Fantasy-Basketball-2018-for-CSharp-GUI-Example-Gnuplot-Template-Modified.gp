reset

BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"
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
Data using 1:4 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting H2H Points
BaseName = BaseName."-H2H Points vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Week Number" font ", 60"

set xrange[:]
set yrange [0:9]

plot \
Data using 1:2 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
unset xrange
unset yrange
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting FT%
BaseName = BaseName."-FT Percentage vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "FT Percentage" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:5 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting 3PTM
BaseName = BaseName."-3 PTM vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "3 PTM" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:6 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting PTS
BaseName = BaseName."-Points vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Points" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:7 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting REB
BaseName = BaseName."-Rebounds vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Rebounds" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:8 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting AST
BaseName = BaseName."-Assists vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Assists" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:9 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting STL
BaseName = BaseName."-Steals vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Steals" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:10 with linespoints ps 5 notitle

unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting BLK
BaseName = BaseName."-Blocks vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Blocks" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:11 with linespoints ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting TO
BaseName = BaseName."-Turnovers vs Week Number"
set output BaseName.".png"

set key bottom right

set ylabel "Turnovers" font ", 60"
set xlabel "Week Number" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 1:12 with linespoints ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"


######################################### Plotting FG% with H2H
BaseName = BaseName."-FG Percentage vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "FG percentage" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 4:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting FT% with H2H
BaseName = BaseName."-FT Percentage vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "FT percentage" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 5:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting 3PTM with H2H
BaseName = BaseName."-3 PTM vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "3 PTM" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 6:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting PTS with H2H
BaseName = BaseName."-Points vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Points" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 7:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting REB with H2H
BaseName = BaseName."-Rebounds vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Rebounds" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 8:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting AST with H2H
BaseName = BaseName."-Assists vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Assists" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 9:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"




######################################### Plotting STL with H2H
BaseName = BaseName."-Steals vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Steals" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 10:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"





######################################### Plotting BLK with H2H
BaseName = BaseName."-Blocks vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Blocks" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 11:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"



######################################### Plotting TO with H2H
BaseName = BaseName."-Turnovers vs H2H"
set output BaseName.".png"

set key bottom right

set ylabel "H2H Points" font ", 60"
set xlabel "Turnovers" font ", 60"

#set xrange[:]
#set yrange [:]

plot \
Data using 12:2 with points ps 5 notitle


unset output
unset xlabel
#unset ylabel
BaseName = "Andres-Fantasy-Basketball-2018-for-CSharp-GUI-Example"


##create .png from .eps
#ConvertString = "i_view64.exe ".BaseName.".eps /convert=".BaseName.".png"
#system ConvertString
