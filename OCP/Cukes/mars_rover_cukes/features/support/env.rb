require 'rspec-expectations'
require 'page-object'

World(PageObject::PageFactory)

$context = "localhost"
$port = "53331" # "53332" # 
$environment = "http://#{$context}:#{$port}"