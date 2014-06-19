Transform /^center of the map$/ do |something|
	'24_24'
end

Transform /^location "(.*?)"$/ do |coordinates|
	puts "In the transformation it is #{coordinates}"   
	coordinates[", "] = "_"
	coordinates
end