for {set i 0} {$i<$x} {incr i} {
	set y [expr 3+0.1*$i]
	PlaceWire 1 $y 2 $y
}