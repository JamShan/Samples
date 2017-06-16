//
//  This file was auto-generated using the ChilliConnect SDK Generator.
//
//  The MIT License (MIT)
//
//  Copyright (c) 2015 Tag Games Ltd
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//

@import Foundation;

#import "ForwardDeclarations.h"

NS_ASSUME_NONNULL_BEGIN

/*!
 An enum describing each of the possible error codes that can be returned from a
 CCRemoveInventoryItemRequest.
 */
typedef NS_ENUM(NSInteger, CCRemoveInventoryItemErrorCode) {
	
	/// A connection could not be established.
	CCRemoveInventoryItemErrorCodeCouldNotConnect = -2,
	
	/// The request timed out.
	CCRemoveInventoryItemErrorCodeTimeout = -1,
	
	/// An unexpected, fatal error has occured on the server. 
	CCRemoveInventoryItemErrorCodeUnexpectedError = 1,
	
	/// Invalid Request. One of more of the provided fields were not correctly formatted.
	/// The data property of the response body will contain specific error messages for
	/// each field.
	CCRemoveInventoryItemErrorCodeInvalidRequest = 1007,
	
	/// Expired Connect Access Token. The Connect Access Token used to authenticate with
	/// the server has expired and should be renewed.
	CCRemoveInventoryItemErrorCodeExpiredConnectAccessToken = 1003,
	
	/// Invalid Connect Access Token. The Connect Access Token was not valid and cannot
	/// be used to authenticate requests.
	CCRemoveInventoryItemErrorCodeInvalidConnectAccessToken = 1004,
	
	/// Temporary Service Error. A temporary error is preventing the request from being
	/// processed.
	CCRemoveInventoryItemErrorCodeTemporaryServiceError = 1008,
	
	/// Inventory Item Not Found. The Inventory Item used in this request could not be
	/// found.
	CCRemoveInventoryItemErrorCodeInventoryItemNotFound = 10303,
	
	/// Inventory Write Conflict. The the WriteLock parameter is out of date. There have
	/// been writes since the previous WriteLock given in the request. Details of the
	/// Attempted and Existing data will be available in the response data attribute.
	CCRemoveInventoryItemErrorCodeInventoryWriteConflict = 10304,
	
	/// Method Disabled. Public access to this method has been disabled on the
	/// ChilliConnect Dashboard.
	CCRemoveInventoryItemErrorCodeMethodDisabled = 1011
};

/*!
 A container for information on any errors that occur during a
 CCRemoveInventoryItemRequest

 This is immutable after construction and is therefore thread safe.
 */
@interface CCRemoveInventoryItemError : NSObject

/// A code describing the error that has occurred.
@property (readonly) CCRemoveInventoryItemErrorCode errorCode;

/// A description of the error that as occurred.
@property (readonly) NSString *errorDescription;

/// Additional, error specific information.
@property (readonly) SCMultiTypeValue *errorData;

/*!
 Convenience factory method for creating new instances of CCRemoveInventoryItemError
 with the given server response.
 
 @param serverResponse The server response. Must represent an error otherwise this will
 assert.

 @return The new instance.
 */
+ (instancetype)removeInventoryItemErrorWithServerResponse:(SCServerResponse *)serverResponse;

/*!
 Convenience factory method for creating new instances of CCRemoveInventoryItemError
 with the given error code.
 
 @param errorCode A code describing the error that has occurred.

 @return The new instance.
 */
+ (instancetype)removeInventoryItemErrorWithErrorCode:(CCRemoveInventoryItemErrorCode)errorCode;

/*!
 Default init method cannot be called for this class.
 */
-(instancetype) __unavailable init;

/*!
 Initialises with the given error code.
 
 @param errorCode A code describing the error that has occurred.
 @param errorData A dictionary of extra information on the specific error that 
        occurred.

 @return The new instance.
 */
- (instancetype)initWithErrorCode:(CCRemoveInventoryItemErrorCode)errorCode errorData:(SCMultiTypeValue *)errorData NS_DESIGNATED_INITIALIZER;

@end

NS_ASSUME_NONNULL_END