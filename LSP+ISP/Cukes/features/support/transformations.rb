Transform /^center of the map$/ do |arg1|
	'25_25'
end

#Transform /^location "(.*?)"$/ do |coordinates|  
#	coordinates[", "] = "_"
#	coordinates
#end

Transform /^display a crater$/ do |name|
	"crater"
end

Transform /^display an obstacle$/ do |name|
	"rock"
end

Transform /^display the ground$/ do |name|
	"Ground"
end

Transform /^the rover$/ do |name|
	"Rover"
end

Transform /^facing North$/ do |direction|
	"-N"
end

Transform /^facing East$/ do |direction|
	"-E"
end

Transform /^facing South$/ do |direction|
	"-S"
end

Transform /^facing West$/ do |direction|
	"-W"
end

#Transform /^default obstacles$/ do |foo|
#	on(MissionPage)
#end

Transform /^(\d+)x(\d+)$/ do |x,y|
	"#{x}_#{y}"
end

Transform /^(\d+) steps$/ do |steps|
	steps.to_i
end
