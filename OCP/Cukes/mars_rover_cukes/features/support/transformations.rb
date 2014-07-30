Transform /^center of the map$/ do |arg1|
	'25_25'
end

Transform /^location "(.*?)"$/ do |coordinates|  
	coordinates[", "] = "_"
	coordinates
end

Transform /^display a crater$/ do |name|
	"crater.jpg"
end

Transform /^display an obstacle$/ do |name|
	"rock.png"
end

Transform /^display the ground$/ do |name|
	"Ground.png"
end

Transform /^default obstacles$/ do |foo|
	on(MissionPage)
end

Transform /^(\d+)x(\d+)$/ do |x,y|
	"#{x}_#{y}"
end

#Transform /^north$/ do |foo|
#	'25_24'
#end