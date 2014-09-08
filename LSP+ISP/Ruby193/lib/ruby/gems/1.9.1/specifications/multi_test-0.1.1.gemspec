# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "multi_test"
  s.version = "0.1.1"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Matt Wynne", "Steve Tooke"]
  s.date = "2014-03-16"
  s.description = "Wafter-thin gem to help control rogue test/unit/autorun requires"
  s.email = "cukes@googlegroups.com"
  s.homepage = "http://cukes.info"
  s.licenses = ["MIT"]
  s.rdoc_options = ["--charset=UTF-8"]
  s.require_paths = ["lib"]
  s.rubygems_version = "1.8.28"
  s.summary = "multi-test-0.1.1"

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
    else
    end
  else
  end
end
