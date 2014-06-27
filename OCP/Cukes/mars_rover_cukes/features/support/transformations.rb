Transform /^center of the map$/ do |something|
	'25_25'
end

Transform /^location "(.*?)"$/ do |coordinates|
	puts "In the transformation it is #{coordinates}"   
	coordinates[", "] = "_"
	coordinates
end