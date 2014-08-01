require 'rspec-expectations'
require 'page-object'

World(PageObject::PageFactory)

$context = "localhost"
$port = "53332" # "53331" # 
$environment = "http://#{$context}:#{$port}"